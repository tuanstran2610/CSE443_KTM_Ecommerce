
//Filter price in Search 

document.addEventListener('DOMContentLoaded', function () {

    handleSwitchPopupImage()
    const minSlider = document.getElementById('minPrice');
    const maxSlider = document.getElementById('maxPrice');
    const priceDisplay = document.getElementById('price-display');
    const sidebarCartEle = document.getElementById("sidebar-cart")
    const myCartEle = document.getElementById("my-cart")
    myCartEle.addEventListener('click', function (event) {
        event.preventDefault();
        sidebarCartEle.classList.toggle("open-cart")
    }
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
        const selectedEle= document.querySelector('.search-category-name[aria-selected="true"]');
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