using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CSE443_KTM_Ecommerce.Migrations
{
    /// <inheritdoc />
    public partial class ProductSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Description", "ImagePath", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 6, 9, 21, 33, 29, 132, DateTimeKind.Local).AddTicks(5753), null, null, "Jersey", null },
                    { 2, new DateTime(2025, 6, 9, 21, 33, 29, 132, DateTimeKind.Local).AddTicks(5767), null, null, "Shoes", null },
                    { 3, new DateTime(2025, 6, 9, 21, 33, 29, 132, DateTimeKind.Local).AddTicks(5768), null, null, "Jacket", null },
                    { 4, new DateTime(2025, 6, 9, 21, 33, 29, 132, DateTimeKind.Local).AddTicks(5769), null, null, "Accessories", null }
                });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Football" },
                    { 2, "Hat" },
                    { 3, "Toy" },
                    { 4, "Scarf" },
                    { 5, "Book/Magazines" },
                    { 6, "Gloves" },
                    { 7, "Bag" },
                    { 8, "Running" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "CategoryId", "CreatedAt", "Description", "Dimensions", "Fabric", "Featured", "ImagePath", "Name", "Price", "ProductTypeId", "Quantity", "Size", "SoldQuantity", "Status", "UpdatedAt", "Warranty", "Weight" },
                values: new object[,]
                {
                    { 1, "manchesterunited", 1, new DateTime(2025, 6, 9, 21, 33, 29, 132, DateTimeKind.Local).AddTicks(5784), "Captain Marvel’s jersey: number 7 for Bryan Robson, United’s longest-serving captain (1982–1994) with 461 appearances. This one-to-one adidas remake celebrates the 1991 Cup Winners’ Cup triumph, featuring detailed cuffs, collar, subtle patterns, and the special cup final badge in classic white away colors.", "36 x 26 x 3 cm", "jacquard", true, null, "Manchester United x adidas Bring Back 1991 Away 7 Printed Jersey White", 160.00m, 1, 25, "XS, S, M, L, XL, 2XL, 3XL", 0, 1, null, "6 months", "0.32 kg" },
                    { 2, "manchesterunited", 1, new DateTime(2025, 6, 9, 21, 33, 29, 132, DateTimeKind.Local).AddTicks(5822), "Relive the early Premier League glory with this Manchester United retro shirt, worn in the 92/93 and 93/94 title-winning seasons. Featuring bold United red and a white contrast collar, it’s perfect for fans celebrating club legends or adding a stylish 90s vibe to their look.", "35 x 25 x 3 cm", "polyester", true, null, "Manchester United 1992-94 Retro Home Shirt Red", 100.00m, 1, 50, "S, M, L, XL, 2XL", 0, 1, null, "6 months", "0.30 kg" },
                    { 3, "manchesterunited", 1, new DateTime(2025, 6, 9, 21, 33, 29, 132, DateTimeKind.Local).AddTicks(5825), "Manchester United at Old Trafford: beloved by fans, respected by rivals. The 24/25 home jersey stands out with bright red side inserts and a subtle gradient design. Made for supporters, it features adidas AEROREADY, an embroidered badge, and 100% recycled materials to help reduce waste and environmental impact.", "34 x 24 x 3 cm", "polyester", true, null, "Manchester United 24/25 Home Jersey", 80.00m, 1, 130, "M, L, XL, 2XL, 3XL", 0, 1, null, "6 months", "0.28 kg" },
                    { 4, "realmadrid", 1, new DateTime(2025, 6, 9, 21, 33, 29, 132, DateTimeKind.Local).AddTicks(5827), "Relive Real Madrid’s 99/00 European triumph with this one-to-one adidas replica of the iconic home jersey. Featuring a Henley collar, classic loose fit, historic TEKA sponsor, and era-specific woven badge, it’s a perfect piece for devoted fans and football fashion lovers.", "35 x 25 x 3 cm", "polyester", true, null, "Real Madrid Home Bring Back 99/00 Jersey White", 140.00m, 1, 30, "XS, S, M, L, XL", 0, 1, null, "6 months", "0.31 kg" },
                    { 5, "realmadrid", 1, new DateTime(2025, 6, 9, 21, 33, 29, 132, DateTimeKind.Local).AddTicks(5828), "Inspired by Madrid’s “chulapo” outfits, this Real Madrid home jersey features a stylish houndstooth pattern, ventilating HEAT.RDY, and a heat-applied badge. Designed for on-pitch performance, it’s made from 100% recycled materials to help reduce waste and environmental impact.", "34 x 24 x 3 cm", "polyester", true, null, "Real Madrid Home Authentic Shirt 24/25 White", 100.00m, 1, 110, "S, M, L, XL, 2XL", 0, 1, null, "6 months", "0.29 kg" },
                    { 6, "barcelona", 1, new DateTime(2025, 6, 9, 21, 33, 29, 132, DateTimeKind.Local).AddTicks(5830), "FC Barcelona 2000/01 Retro Nike Jersey: features commemorative collab woven label, embroidered Swoosh and retro FCB crest, printed skeleton graphic on front, plus Cactus Jack spray logo, CJ classic logo, #2, and Barça motif on back.", "37 x 27 x 3 cm", "polyester", true, null, "CJ X Nike X FC Barcelona Retro 2000/01 Home Skeleton Jersey", 200.00m, 1, 5, "XS, S, M, L, XL, 2XL, 3XL", 0, 1, null, "6 months", "0.35 kg" },
                    { 7, "barcelona", 1, new DateTime(2025, 6, 9, 21, 33, 29, 132, DateTimeKind.Local).AddTicks(5833), "Limited edition of 1,899, this CJ x Nike x FCB men’s athletic-fit jersey comes in a custom collector’s box with a numbered certificate of authenticity. Made with Nike Dri-FIT ADV performance material, it features Cactus Jack, Nike, and FCB logo details.", "36 x 26 x 3 cm", "polyester", true, null, "FC Barcelona 2024/25 Match Home X Cactus Jack Jersey", 150.00m, 1, 4, "S, M, L, XL, 2XL", 0, 1, null, "6 months", "0.33 kg" },
                    { 8, "acmilan", 1, new DateTime(2025, 6, 9, 21, 33, 29, 132, DateTimeKind.Local).AddTicks(5835), "The 25/26 AC Milan Home Kit turns up the heat with iconic Red & Black, flame-detailed stripes, and a bold red crest. A modern take on the founders’ vision: red like flames, black like fear. Rossoneri, bring the heat.", "35 x 25 x 3 cm", "polyester", true, null, "AC Milan Home Authentic 2025/26 JERSEY", 163.00m, 1, 110, "XS, S, M, L, XL, 2XL", 0, 1, null, "6 months", "0.34 kg" },
                    { 9, "acmilan", 1, new DateTime(2025, 6, 9, 21, 33, 29, 132, DateTimeKind.Local).AddTicks(5837), "From 1963 to forever. Co-created by PUMA, AC Milan, and Off-White™, this jersey honors Milan’s first European Cup triumph and a world driven by progress. With two alternative colorways and signature Off-White™ details, it celebrates unity and reminds us: change is unstoppable, so dream on.", "34 x 24 x 3 cm", "polyester", true, null, "AC Milan x OFF-WHITE™ Replica Jersey Men", 150.00m, 1, 15, "M, L, XL, 2XL, 3XL", 0, 1, null, "6 months", "0.31 kg" },
                    { 10, "bayern", 1, new DateTime(2025, 6, 9, 21, 33, 29, 132, DateTimeKind.Local).AddTicks(5838), "The official Bayern München Authentic Away Jersey for the 2025/26 season combines cutting-edge performance with classic club pride. Featuring a gestickt (embroidered) Bayern crest and adidas logo, this jersey is crafted with atmungsaktiv (breathable) materials for ultimate comfort on and off the pitch. Designed for elite performance, it showcases premium adidas engineering and unmistakable Bayern style.", "36 x 26 x 3 cm", "polyester", true, null, "Bayern Muchen Authentic Away Jersey 25-26", 130.00m, 1, 130, "S, M, L, XL, 2XL, 3XL", 0, 1, null, "6 months", "0.33 kg" },
                    { 11, "psg", 1, new DateTime(2025, 6, 9, 21, 33, 29, 132, DateTimeKind.Local).AddTicks(5840), "The PSG Home Kit 2024/25 delivers a fresh take on the classic Hechter design, inspired by the urban art of Greater Paris. Featuring the iconic central red band framed by thin white brushstroke-style lines, this modern jersey captures the bold, disruptive spirit of a club known as the team of the new generation.", "34 x 24 x 3 cm", "polyester", true, null, "PSG Nike Home Stadium Shirt 2024-25", 85.00m, 1, 120, "S, M, L, XL", 0, 1, null, "6 months", "0.28 kg" },
                    { 12, "intermilan", 1, new DateTime(2025, 6, 9, 21, 33, 29, 132, DateTimeKind.Local).AddTicks(5842), "For the first time, the second star shines above the logo on the 2024/25 Home Kit. Part of the Match collection, this jersey features Nike Dri-FIT ADV technology, combining lightweight, quick-drying, and breathable fabric for maximum comfort on the pitch. Made from recycled polyester and crafted with athlete-tested design, it’s the exact kit worn by the stars. Customize it with your favorite player’s name, number, and add Lega Serie A 2024/25 or Champions League sleeve patches.", "35 x 25 x 3 cm", "polyester", true, null, "Inter Milan Nike Home Match Jersey 2024/25", 130.00m, 1, 110, "M, L, XL, 2XL, 3XL", 0, 1, null, "6 months", "0.32 kg" },
                    { 13, "dortmund", 1, new DateTime(2025, 6, 9, 21, 33, 29, 132, DateTimeKind.Local).AddTicks(5844), "A true classic! The Borussia Dortmund 24/25 home shirt features a timeless design with black sleeves and four thin stripes across the iconic yellow base. On the back, bold black “Dortmund” lettering stands out, complemented by subtle stripes running from front to back. The club motto, Borussia verbindet (Borussia unites), is delicately placed on the collar, completing this elegant look.", "33 x 23 x 3 cm", "polyester", true, null, "Borussia Dortmund 24/25 Home Jersey", 65.00m, 1, 140, "S, M, L, XL", 0, 1, null, "6 months", "0.27 kg" },
                    { 14, "nike", 2, new DateTime(2025, 6, 9, 21, 33, 29, 132, DateTimeKind.Local).AddTicks(5845), "Want to elevate your speed? These Academy Shoes feature an upgraded heel Air Zoom unit, delivering the explosive, propulsive feel you — and Kylian Mbappé — need to break past defenders. The most responsive Mercurial yet, built to help you control pace and tempo all match long.", "30 x 10 x 12 cm", "Synthetic Flyknit upper with mesh", true, null, "Nike Mercurial Vapor 16 Academy 'Kylian Mbappé'", 110.00m, 1, 20, "39, 40, 41, 42, 43, 44, 45", 0, 1, null, "12 months", "220g (per shoe, size 42)" },
                    { 15, "nike", 2, new DateTime(2025, 6, 9, 21, 33, 29, 132, DateTimeKind.Local).AddTicks(5847), "Looking to elevate your speed? These Academy Shoes feature an enhanced heel Air Zoom unit, giving you — and Kylian Mbappé — the explosive push to break through defenses. It’s the most responsive Mercurial we’ve ever created, built to help you control pace and tempo all match long.", "31 x 10 x 13 cm", "Flyknit upper, synthetic overlays", true, null, "Nike Mercurial Superfly 10 Academy 'Kylian Mbappé'", 130.00m, 1, 18, "39, 40, 41, 42, 43, 44, 45", 0, 1, null, "12 months", "230g (per shoe, size 42)" },
                    { 16, "nike", 2, new DateTime(2025, 6, 9, 21, 33, 29, 132, DateTimeKind.Local).AddTicks(5851), "Looking to take your game to the next level? The Phantom GX 2 Academy helps put you in prime position of the goal, whether you're the playmaker, assister or finisher. The rest is up to you. Created with goals in mind, NikeSkin covers the striking area of the shoe, while sticky traction helps guide your unscripted agility on the turf.", "30 x 10 x 12 cm", "Synthetic NikeSkin upper, rubber outsole", true, null, "Nike Phantom GX 2 Academy", 100.00m, 1, 90, "39, 40, 41, 42, 43, 44, 45", 0, 1, null, "12 months", "240g (per shoe, size 42)" },
                    { 17, "adidas", 2, new DateTime(2025, 6, 9, 21, 33, 29, 132, DateTimeKind.Local).AddTicks(5852), "Find your fast and express yourself on the pitch with adidas F50 boots, built for pure speed. Featuring a thin Fibertouch upper, Compression Fit Tunnel Tongue for secure lockdown, and Sprintweb 3D texture for close control, these Elite boots deliver. The Sprintframe 360 outsole adds spring and support, keeping you unstoppable on dry grass pitches.", "31 x 11 x 12 cm", "Fibertouch synthetic upper, Sprintframe outsole", true, null, "Adidas F50 Elite Firm Ground Boots", 200.00m, 1, 70, "38, 39, 40, 41, 42, 43, 44, 45", 0, 1, null, "12 months", "210g (per shoe, size 42)" },
                    { 18, "adidas", 2, new DateTime(2025, 6, 9, 21, 33, 29, 132, DateTimeKind.Local).AddTicks(5854), "Discover the difference between hoping to score and knowing you will with adidas Predator boots, built for goals. These League boots feature a Hybridfeel upper with all-over 3D texture and grippy Strikescale fins for precise ball control. A lug rubber outsole ensures stability on artificial turf pitches.", "30 x 11 x 12 cm", "Hybridfeel synthetic upper, rubber outsole", true, null, "Adidas Predator League Turf Boots", 95.00m, 1, 100, "38, 39, 40, 41, 42, 43, 44, 45", 0, 1, null, "12 months", "260g (per shoe, size 42)" },
                    { 19, "adidas", 2, new DateTime(2025, 6, 9, 21, 33, 29, 132, DateTimeKind.Local).AddTicks(5856), "Push your pace to the limit with lightweight adidas F50 boots, engineered for pure speed. Featuring an eye-catching Sprintgrid print, the Fiberskin upper and adaptive Tunnel Tongue provide a secure fit. Underfoot, the Sprintplate 360 outsole delivers extra acceleration on firm ground and artificial grass. Made with at least 20% recycled materials to help reduce waste and environmental impact.", "31 x 11 x 12 cm", "Fiberskin synthetic upper, Sprintplate outsole", true, null, "Adidas F50 League Firm/Multi-Ground Boots", 90.00m, 1, 90, "38, 39, 40, 41, 42, 43, 44, 45", 0, 1, null, "12 months", "220g (per shoe, size 42)" },
                    { 20, "adidas", 2, new DateTime(2025, 6, 9, 21, 33, 29, 132, DateTimeKind.Local).AddTicks(5858), "Feel the rush of speed in the Adizero Evo SL. Inspired by the record-breaking innovation of the Adizero Pro Evo 1, this shoe blends race-day performance with everyday style. Featuring LIGHTSTRIKE PRO foam for responsive cushioning and energy return, it’s built to move—whether you are running or just living life in the fast lane.", "29 x 10 x 11 cm", "Primeknit upper, LIGHTSTRIKE PRO foam midsole", true, null, "Adizero Evo SL Men", 190.00m, 8, 60, "40, 41, 42, 43, 44, 45, 46", 0, 1, null, "12 months", "180g (per shoe, size 42)" },
                    { 21, "adidas", 2, new DateTime(2025, 6, 9, 21, 33, 29, 132, DateTimeKind.Local).AddTicks(5859), "The Ultraboost 5 is built for your most energized run yet. Featuring Light BOOST V2—adidas’ highest energy return cushioning—it delivers unmatched comfort with less weight. A PRIMEKNIT upper adapts to your foot for a perfect fit, while the moulded heel support and Torsion System provide stability and smooth transitions. Finished with a Continental™ outsole for superior grip, this is performance at its peak.", "30 x 11 x 12 cm", "Primeknit upper, BOOST midsole, Continental rubber outsole", true, null, "Adidas Ultraboost 5", 200.00m, 8, 70, "40, 41, 42, 43, 44, 45, 46", 0, 1, null, "12 months", "310g (per shoe, size 42)" },
                    { 22, "manchesterunited", 3, new DateTime(2025, 6, 9, 21, 33, 29, 132, DateTimeKind.Local).AddTicks(5861), "Button up this loose-fitting Manchester United jacket to celebrate Chinese New Year in style. Featuring a golden crest and the iconic devil symbol, it’s a bold way to show your club pride during the festivities. Made with a smooth plain weave shell and soft single jersey lining, this adidas jacket offers all-day comfort. Designed with UNITEFIT, an all-gender fit system created for diverse sizes and shapes, it’s perfect for everyone.", "60x40x5 cm", "plain weave shell, single jersey lining", true, null, "Manchester United x adidas Chinese New Year Jacket Black", 200.00m, 1, 120, "XS, S, M, L, XL, 2XL, 3XL", 0, 1, null, "12 months", "850" },
                    { 23, "manchesterunited", 3, new DateTime(2025, 6, 9, 21, 33, 29, 132, DateTimeKind.Local).AddTicks(5863), "An ode to football history, this Manchester United track top blends iconic club details with adidas archive-inspired style. Its loose fit and smooth fabric keep you comfortable while you represent. The chest features a classic Trefoil alongside a red devil badge, capturing the spirit of the beautiful game. Made with at least 70% recycled materials, it helps reduce waste and environmental impact.", "58x38x4 cm", "polyester blend with recycled content", true, null, "Manchester United Originals Track Top", 160.00m, 1, 150, "S, M, L, XL, 2XL", 0, 1, null, "12 months", "700" },
                    { 24, "acmilan", 3, new DateTime(2025, 6, 9, 21, 33, 29, 132, DateTimeKind.Local).AddTicks(5865), "Rooted in AC Milan’s history, this collection blends the club’s iconic devil mascot and classic red and black with vintage football and “125” anniversary graphics, accented in gold to honor its legacy. Featuring Off-White™ silhouettes for adults and kids—including varsity jackets, hoodies, and tees—plus accessories like caps, scarves, luggage, and socks. Entirely conceptualized and designed in Milan, the varsity jacket is Made in Italy with premium craftsmanship and gold-satin embroidery, celebrating both AC Milan and Off-White™ heritage.", "65x45x6 cm", "cotton blend with satin embroidery", true, null, "AC Milan X Off-White- Varsity Jacket", 2950.00m, 1, 40, "M, L, XL, 2XL", 0, 1, null, "24 months", "1200" },
                    { 25, "realmadrid", 3, new DateTime(2025, 6, 9, 21, 33, 29, 132, DateTimeKind.Local).AddTicks(5867), "Comfort meets fandom in this adidas training jacket, perfect for showing your Real Madrid pride at the stadium or from home. Ribbed details and soft jersey fabric deliver a cozy fit, while the embroidered club logo and classic white-and-blue colors make your allegiance clear.", "59x39x4 cm", "jersey fabric with ribbed trims", true, null, "Real Madrid Adidas DNA Track Top 24/25 White", 100.00m, 1, 180, "S, M, L, XL, 2XL", 0, 1, null, "12 months", "750" },
                    { 26, "intermilan", 3, new DateTime(2025, 6, 9, 21, 33, 29, 132, DateTimeKind.Local).AddTicks(5869), "The pre-match INTER anthem jacket is the same one worn by your favourite players when they take to the pitch during big Champions League nights. Perfect to wear over your jersey, it provides ideal warmth as you cheer on the Nerazzurri.", "60x40x5 cm", "polyester with mesh lining", true, null, "Inter Milan Nike Pre-Match Champions League Anthem Jacket", 130.00m, 1, 140, "S, M, L, XL, 2XL, 3XL", 0, 1, null, "12 months", "800" },
                    { 27, "psg", 3, new DateTime(2025, 6, 9, 21, 33, 29, 132, DateTimeKind.Local).AddTicks(5871), "Made in Italy, the Jordan Wings x PSG Varsity Jacket blends premium materials with timeless sport style. Featuring a cashmere-blend body, leather shoulder panels in a wing-inspired design, and an allover embroidered ICI C’EST PARIS monogram, it’s finished with a matching satin lining and ribbed cuffs and collar. Available in Blue Void, this jacket delivers a truly standout look.", "66x46x6 cm", "cashmere blend with leather panels", true, null, "PSG x Jordan Wings Cashmere and Leather Varsity Jacket - Blue Void", 2100.00m, 1, 50, "M, L, XL", 0, 1, null, "24 months", "1400" },
                    { 28, "manchesterunited", 4, new DateTime(2025, 6, 9, 21, 33, 29, 132, DateTimeKind.Local).AddTicks(5872), "Show your United pride with this official bucket hat, inspired by the design gifted at the 22/23 FA Cup final and revived by fans during the 23/24 celebrations. Featuring bar stripes in fan flag colours and an embroidered devil on the visor, it’s a timeless accessory for true supporters. Made from soft cotton twill for all-day comfort.", "30x30x15 cm", "cotton twill", true, null, "Manchester United x New Era Bar Stripe Bucket Hat", 30.00m, 2, 200, "S, M, L", 0, 1, null, "12 months", "150" },
                    { 29, "manchesterunited", 4, new DateTime(2025, 6, 9, 21, 33, 29, 132, DateTimeKind.Local).AddTicks(5874), "Perfect for young fans, this Fred the Red plush is a fun matchday companion or a charming addition to any United-themed room. Dressed in a bucket hat and red devil tee, this mascot toy sports a classic fan look—bringing Manchester United style and spirit home. A great gift for supporters of all ages.", "20x15x15 cm", "plush fabric", true, null, "Manchester United Bucket Hat Fred the Red Plush Red", 25.00m, 3, 150, "One Size", 0, 1, null, "12 months", "300" },
                    { 30, "manchesterunited", 4, new DateTime(2025, 6, 9, 21, 33, 29, 132, DateTimeKind.Local).AddTicks(5875), "A stylish gift for any Manchester United fan, this official scarf pairs effortlessly with any outfit while adding a subtle nod to the club. Featuring a sleek black design with white and gold stripes, it’s finished with gold embroidered devils to show your allegiance. Packaged in a premium gift box, it’s the perfect present for the Reds in your life.", "180x25x5 cm", "acrylic blend", true, null, "Manchester United Bar Scarf Gift Box Black", 20.00m, 4, 250, "One Size", 0, 1, null, "12 months", "250" },
                    { 31, "manchesterunited", 4, new DateTime(2025, 6, 9, 21, 33, 29, 132, DateTimeKind.Local).AddTicks(5877), "Bring Old Trafford to life with this BRXLZ stadium kit, a must-have for any Manchester United fan. Recreate the iconic Sir Alex Ferguson Stand and experience the magic of the Theatre of Dreams piece by piece. Perfect for model builders or newcomers alike, this detailed kit makes a great gift—and a proud display of your United loyalty once complete.", "35x30x15 cm", "plastic bricks", true, null, "Manchester United BRXLZ Large Old Trafford Stadium", 110.00m, 3, 100, "One Size", 0, 1, null, "12 months", "1200" },
                    { 32, "manchesterunited", 4, new DateTime(2025, 6, 9, 21, 33, 29, 132, DateTimeKind.Local).AddTicks(5879), "Add a distinctive piece to your collection with this official Manchester United illustrated football. Featuring detailed line drawings by Manchester artist Izzy Winter, the design showcases iconic views of Old Trafford, the city, and club legends. A size 5 ball, it’s perfect as a display piece or a thoughtful keepsake for any devoted fan.", "22x22x22 cm", "synthetic leather", true, null, "Manchester United Size 5 Illustrated Football White", 100.00m, 1, 180, "Size 5", 0, 1, null, "12 months", "450" },
                    { 33, "manchesterunited", 4, new DateTime(2025, 6, 9, 21, 33, 29, 132, DateTimeKind.Local).AddTicks(5880), "The perfect finishing touch for any young fan’s outfit, this classic kids’ baseball cap features the iconic Manchester United crest for a bold show of team pride. Made from breathable cotton twill with a low crown and adjustable D-ring closure, it offers all-day comfort and effortless summer style. A must-have for every junior Red.", "28x28x12 cm", "cotton twill", true, null, "Manchester United x New Era Kids 9Forty Core Cap", 26.00m, 2, 220, "Kids", 0, 1, null, "12 months", "120" },
                    { 34, "manchesterunited", 4, new DateTime(2025, 6, 9, 21, 33, 29, 132, DateTimeKind.Local).AddTicks(5925), "Relive the rise of a football icon in Wayne Rooney: Teenage Kicks. From his early days at Everton to his record-breaking years at Manchester United, this biography explores the key moments of Rooney’s legendary career. Packed with era-defining highlights and behind-the-scenes stories, it’s a must-read for fans eager to learn more about one of football’s greatest talents—a perfect gift for any United supporter.", "20x13x3 cm", "paper", true, null, "Wayne Rooney, Teenage Kicks Book", 26.00m, 5, 300, "One Size", 0, 1, null, "No warranty", "350" },
                    { 35, "adidas", 4, new DateTime(2025, 6, 9, 21, 33, 29, 132, DateTimeKind.Local).AddTicks(5926), "From daily workouts to game day, these adidas crew-length socks are built for comfort and support. With targeted arch compression and cushioning at the heels and toes, they reduce pressure so you can stay focused on your performance—whether you're training, lifting, or playing.", "25x10x5 cm", "cotton blend", true, null, "Cushioned Crew Socks 3 Pairs", 10.00m, 6, 500, "S, M, L", 0, 1, null, "6 months", "90" },
                    { 36, "adidas", 4, new DateTime(2025, 6, 9, 21, 33, 29, 132, DateTimeKind.Local).AddTicks(5928), "The backpack is back—and better than ever. This adidas classic blends style and function, with space for everything from your laptop to your gym gear. A side pocket keeps your water bottle within easy reach, while its clean design makes it a go-to for daily use.", "45x30x15 cm", "polyester", true, null, "Classic Badge Of Sport Backpack", 25.00m, 7, 150, "One Size", 0, 1, null, "12 months", "900" },
                    { 37, "adidas", 4, new DateTime(2025, 6, 9, 21, 33, 29, 132, DateTimeKind.Local).AddTicks(5930), "Sharpen your skills with adidas Predator Training goalkeeper gloves. Designed for reliable grip and comfort, they feature a cushioned Soft Grip latex palm, flexible backhand, and a roomy finger cut for confident saves. An adjustable elastic bandage strap ensures a secure, stable fit so you can focus on every shot.", "25x15x5 cm", "latex and polyester", true, null, "Predator Training Goalkeeper Gloves", 38.00m, 8, 180, "S, M, L", 0, 1, null, "12 months", "300" },
                    { 38, "adidas", 4, new DateTime(2025, 6, 9, 21, 33, 29, 132, DateTimeKind.Local).AddTicks(5932), "Designed to complement your everyday look, this adidas shoulder bag offers sleek, effortless style. Featuring a clean, minimalist design with an embossed Trefoil logo and refined outline stitching, it holds your essentials with ease. The padded shoulder strap ensures all-day comfort wherever you go.", "35x20x10 cm", "polyester", true, null, "Outline Trefoil Shoulder Bag", 55.00m, 7, 120, "One Size", 0, 1, null, "12 months", "600" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Name",
                table: "Categories",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
