
//Filter price in Search


document.addEventListener('click', function (e) {
    const target = e.target.closest('.view-detail-btn');
    if (target) {
        const productId = target.getAttribute('data-product-id');
        console.log("Clicked on productId:", productId); // ✅ Debug

        const modalContent = document.getElementById('view-product-detail-container');

        modalContent.innerHTML = `<div class="p-5 text-center">Loading...</div>`;
       

        fetch(`/Cart/GetProductDetail?productId=${productId}`)
            .then(response => response.text())
            .then(html => {
                modalContent.innerHTML = html;
            })
            .catch(error => {
                modalContent.innerHTML = `<div class="p-5 text-danger text-center">Failed to load product detail.</div>`;
                console.error("Fetch error:", error);
            });
    }
});
document.addEventListener("click", function (e) {
    const removeBtn = e.target.closest(".cart-remove-btn");
    if (removeBtn) {
        const cartItemId = parseInt(removeBtn.getAttribute("data-id"));
        const removeType = removeBtn.getAttribute("data-type");
        if (!isNaN(cartItemId)) {
            fetch("/Cart/RemoveFromCart", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify(cartItemId)
            })
                .then(res => res.json())
                .then(data => {
                    if (data.success) {
                        if (removeType === "reload") {
                            window.location.reload()
                        }
                        updateCartMini();
                        updateCartView();
                    } else {
                        alert("Error removing item." + data.error);
                    }
                })
                .catch(err => console.error("Remove error:", err));
        }
    }
});
document.addEventListener("click", function (e) {
    const addBtn = e.target.closest(".addToCartBtn");
    if (addBtn) {
        const productId = addBtn.getAttribute("data-product-id");

        // If inside a modal or specific container, this ensures the correct quantity field is fetched
        const productQuantityEle = document.getElementById("product-quantity");
        const quantity = productQuantityEle ? parseInt(productQuantityEle.value) : 1;

        fetch("/Cart/AddToCart", {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify({
                ProductId: productId,
                Quantity: quantity
            })
        })
            .then(res => res.json())
            .then(data => {
                if (data.success) {
                    updateCartMini();
                    updateCartView();
                } else {
                    alert("Failed to add product to cart.");
                }
            })
            .catch(err => console.error("Add to cart error:", err));
    }
});

//document.querySelectorAll(".addToCartBtn").forEach(function (button) {
//    button.addEventListener("click", function () {
//        const productId = this.getAttribute("data-product-id");
//        const productQuantityEle = document.getElementById("product-quantity");
//        const quantity = productQuantityEle ? parseInt(productQuantityEle.value) : 1;

//        fetch("/Cart/AddToCart", {
//            method: "POST",
//            headers: {
//                "Content-Type": "application/json",
//            },
//            body: JSON.stringify({
//                ProductId: productId,
//                Quantity: quantity
//            })
//        })
//            .then(res => res.json())
//            .then(data => {
//                if (data.success) {
//                    updateCartMini();
//                    updateCartView();
//                }
//            });
//    });
//});
document.getElementById("addToCartBtn").addEventListener("click", function () {
    const productId = this.getAttribute("data-product-id");
    const productQuantityEle = document.getElementById("product-quantity")
    const quantity = parseInt(productQuantityEle.value);
    fetch("/Cart/AddToCart", {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify({
            ProductId: productId,
            Quantity: productQuantityEle ? quantity : 1
        })
    })
        .then(res => res.json())
        .then(data => {
            if (data.success) {
                updateCartMini();
                updateCartView();
            }
        });


});

function updateCartMini() {
    fetch("/CartMini")
        .then(res => res.text())
        .then(html => {
            document.getElementById("cart-mini-container").innerHTML = html;
        });
}
function updateCartView() {
    fetch("/CartView")
        .then(res => res.text())
        .then(html => {
            document.getElementById("sidebar-cart").innerHTML = html;
        });
}



document.addEventListener('DOMContentLoaded', function () {


    handleSwitchPopupImage()
    const minSlider = document.getElementById('minPrice');
    const maxSlider = document.getElementById('maxPrice');
    const priceDisplay = document.getElementById('price-display');

    const myCartEle = document.getElementById("my-cart")

    function updatePriceDisplay() {
        let minVal = parseInt(minSlider.value);
        let maxVal = parseInt(maxSlider.value);
        if (minVal > maxVal) {
            [minVal, maxVal] = [maxVal, minVal]; // Swap if needed
        }
        priceDisplay.textContent = `$${minVal} - $${maxVal}`;
    }

    minSlider.addEventListener('input', updatePriceDisplay);
    maxSlider.addEventListener('input', updatePriceDisplay);

    window.applyPriceFilter = function () {
        console.log("filter price !!")
        const currentUrl = new URL(window.location.href);
        const params = currentUrl.searchParams;

        let min = parseInt(minSlider.value);
        let max = parseInt(maxSlider.value);
        if (min > max) [min, max] = [max, min];
        params.set('minPrice', min);
        params.set('maxPrice', max);
        window.location.href = currentUrl.toString();
        //alert(`Filtering products from $${min} to $${max}`);
        // Replace this alert with your real filtering logic
    };

    // Initialize the display
    updatePriceDisplay();


    ///  Category Product Count View Initialization
    const categoryLinks = document.querySelectorAll('.category-link'); // Select all links with this class
    categoryLinks.forEach(link => {
        link.addEventListener('click', function (event) {
            event.preventDefault(); // Prevent the default link navigation
            const currentUrl = new URL(window.location.href);
            const params = currentUrl.searchParams;
            // Get the category name from the data-category-name attribute of the clicked link
            const clickedCategoryName = this.dataset.categoryName;

            if (clickedCategoryName === 'clear') {
                params.delete('category'); // Remove the 'category' parameter
            } else {
                params.set('category', clickedCategoryName); // Set or update the 'category' parameter
            }

            // Navigate to the new URL with updated parameters
            window.location.href = currentUrl.toString();
        });
    });
    const selectedCategory = new URL(window.location.href).searchParams.get('category');
    if (selectedCategory) {
        categoryLinks.forEach(link => {
            // Check if the link's data-category-name matches the selected category (case-insensitive)
            if (link.dataset.categoryName && link.dataset.categoryName.toLowerCase() === selectedCategory.toLowerCase()) {
                // Add 'active' class to the parent <li> of the link
                // Assuming your link is inside an <li>, like in the previous example
                link.closest('li').classList.add('category-product-active');
            }
        });
    }

}
);

function handleSwitchPopupImage() {
    // 1. Select all the thumbnail buttons.
    // We're using the 'product-thumbnail-button' class we added in HTML.
    const thumbnailButtons = document.querySelectorAll('.product-thumbnail-button');

    // 2. Get the target element (the link that will open the larger image).
    // Assuming 'popup-image' refers to a single <a> tag.
    const popupImageLink = document.querySelector('.popup-image');

    // --- Basic validation: Ensure target link exists ---
    if (!popupImageLink) {
        console.error("Error: Element with class 'popup-image' (your target link) not found.");
        return; // Stop the function if the target isn't there
    }

    // 3. Loop through each thumbnail button and add a click event listener.
    thumbnailButtons.forEach(button => {
        button.addEventListener('click', function (event) {
            // Optional: If the button's data-bs-toggle="tab" causes undesired behavior,
            // you might want to prevent its default action, but typically Bootstrap
            // handles this well.
            // event.preventDefault();

            // Find the <img> element directly inside the clicked button.
            const imageElement = this.querySelector('img');

            if (imageElement) {
                // Get the 'src' attribute value from the <img> tag.
                const imageUrl = imageElement.src;

                // Assign this 'src' value to the 'href' attribute of the popup link.
                popupImageLink.href = imageUrl;

                // Optional: If you also have a main <img> element that displays the image,
                // you would update its 'src' here as well.
                // const mainDisplayImage = document.getElementById('current-main-image');
                // if (mainDisplayImage) {
                //     mainDisplayImage.src = imageUrl;
                // }

                console.log(`Popup link href updated to: ${imageUrl}`);
            } else {
                console.warn("Clicked button does not contain an <img> element.");
            }
        });
    });
}
function handleClearAllFilters() {
    const currentUrl = new URL(window.location.href);
    const params = currentUrl.searchParams;
    // Create an array of parameter names to avoid modifying the collection while iterating
    const paramNames = [];
    params.forEach((value, key) => {
        paramNames.push(key);
    });

    // Delete each parameter
    paramNames.forEach(key => {
        params.delete(key);
    });
    window.location.href = currentUrl.toString();
    // Update the URL without reloading the page
    //window.history.pushState({}, '', currentUrl.toString());
}

function handleSubmitSearchProductForm(event) {
    event.preventDefault()
    const searchProductEle = document.getElementById("search-product")
    if (searchProductEle) {
        const search = searchProductEle.value;
        const selectedEle = document.querySelector('.search-category-name[aria-selected="true"]');
        if (selectedEle) {
            const currentUrl = new URL(window.location.href);
            const params = currentUrl.searchParams;
            // Create an array of parameter names to avoid modifying the collection while iterating
            const paramNames = [];
            params.forEach((value, key) => {
                paramNames.push(key);
            });

            // Delete each parameter
            paramNames.forEach(key => {
                params.delete(key);
            });
            let category = selectedEle.getAttribute("data-category-name");
            //if (category) {
            //    params.set('category', category)
            //}

            window.location.href = `/Product/Search?title=${search}&category=${category}`;
            console.log(category)
        }
    }
}


async function handleAddToCart() {
    const sidebarCartEle = document.querySelector(".cart_sidebar");
    const returnUrl = window.location.href;
    console.log(sidebarCartEle)
    const productIdEle = document.getElementById("product-id");
    const productQuantityEle = document.getElementById("product-quantity")

    if (productIdEle && productQuantityEle) {
        const productId = parseInt(productIdEle.value);
        const quantity = parseInt(productQuantityEle.value);
        const response = await fetch('/Cart/AddToCart', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                ProductId: productId,
                Quantity: quantity,
                ReturnUrl: returnUrl
            })
        });

        if (response.redirected) {
            // Redirect to the returned URL from server
            window.location.href = response.url;
            sidebarCartEle.classList.add("open-cart");
        } else if (response.ok) {
            // Optionally update cart UI or show success
            console.log("Item added to cart.");
        } else {
            const error = await response.text();
            console.error("Error adding to cart:", error);
        }
    }
}