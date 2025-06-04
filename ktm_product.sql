use KTM;

SELECT * FROM products;

CREATE TABLE products (
    id INT IDENTITY(1,1) PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    category VARCHAR(100),
    type VARCHAR(100),
    brand VARCHAR(100),
    description TEXT,
    price DECIMAL(10, 2),
    path VARCHAR(255),
    weight VARCHAR(50),
    dimensions VARCHAR(100),
    size VARCHAR(100),
    fabric VARCHAR(100),
    warranty VARCHAR(50),
    quantity INT,	
);


INSERT INTO products (
    name, category, type, brand, description, price, path, weight, dimensions, size, fabric, warranty, quantity
) VALUES
('Manchester United x adidas Bring Back 1991 Away 7 Printed Jersey White', 'jersey', 'football', 'manchesterunited',
'Captain Marvel’s jersey: number 7 for Bryan Robson, United’s longest-serving captain (1982–1994) with 461 appearances. This one-to-one adidas remake celebrates the 1991 Cup Winners’ Cup triumph, featuring detailed cuffs, collar, subtle patterns, and the special cup final badge in classic white away colors.',
160.00, 'product_data/jerseys/manchesterunited/product1', '0.32 kg', '36 x 26 x 3 cm', 'XS, S, M, L, XL, 2XL, 3XL', 'jacquard', '6 months', 25),

('Manchester United 1992-94 Retro Home Shirt Red', 'jersey', 'football', 'manchesterunited',
'Relive the early Premier League glory with this Manchester United retro shirt, worn in the 92/93 and 93/94 title-winning seasons. Featuring bold United red and a white contrast collar, it’s perfect for fans celebrating club legends or adding a stylish 90s vibe to their look.',
100.00, 'product_data/jerseys/manchesterunited/product2', '0.30 kg', '35 x 25 x 3 cm', 'S, M, L, XL, 2XL', 'polyester', '6 months', 50),

('Manchester United 24/25 Home Jersey', 'jersey', 'football', 'manchesterunited',
'Manchester United at Old Trafford: beloved by fans, respected by rivals. The 24/25 home jersey stands out with bright red side inserts and a subtle gradient design. Made for supporters, it features adidas AEROREADY, an embroidered badge, and 100% recycled materials to help reduce waste and environmental impact.',
80.00, 'product_data/jerseys/manchesterunited/product3', '0.28 kg', '34 x 24 x 3 cm', 'M, L, XL, 2XL, 3XL', 'polyester', '6 months', 130),

('Real Madrid Home Bring Back 99/00 Jersey White', 'jersey', 'football', 'realmadrid',
'Relive Real Madrid’s 99/00 European triumph with this one-to-one adidas replica of the iconic home jersey. Featuring a Henley collar, classic loose fit, historic TEKA sponsor, and era-specific woven badge, it’s a perfect piece for devoted fans and football fashion lovers.',
140.00, 'product_data/jerseys/realmadrid/product1', '0.31 kg', '35 x 25 x 3 cm', 'XS, S, M, L, XL', 'polyester', '6 months', 30),

('Real Madrid Home Authentic Shirt 24/25 White', 'jersey', 'football', 'realmadrid',
'Inspired by Madrid’s “chulapo” outfits, this Real Madrid home jersey features a stylish houndstooth pattern, ventilating HEAT.RDY, and a heat-applied badge. Designed for on-pitch performance, it’s made from 100% recycled materials to help reduce waste and environmental impact.',
100.00, 'product_data/jerseys/realmadrid/product2', '0.29 kg', '34 x 24 x 3 cm', 'S, M, L, XL, 2XL', 'polyester', '6 months', 110),

('CJ X Nike X FC Barcelona Retro 2000/01 Home Skeleton Jersey', 'jersey', 'football', 'barcelona',
'FC Barcelona 2000/01 Retro Nike Jersey: features commemorative collab woven label, embroidered Swoosh and retro FCB crest, printed skeleton graphic on front, plus Cactus Jack spray logo, CJ classic logo, #2, and Barça motif on back.',
200.00, 'product_data/jerseys/barcelona/product1', '0.35 kg', '37 x 27 x 3 cm', 'XS, S, M, L, XL, 2XL, 3XL', 'polyester', '6 months', 5),

('FC Barcelona 2024/25 Match Home X Cactus Jack Jersey', 'jersey', 'football', 'barcelona',
'Limited edition of 1,899, this CJ x Nike x FCB men’s athletic-fit jersey comes in a custom collector’s box with a numbered certificate of authenticity. Made with Nike Dri-FIT ADV performance material, it features Cactus Jack, Nike, and FCB logo details.',
150.00, 'product_data/jerseys/barcelona/product2', '0.33 kg', '36 x 26 x 3 cm', 'S, M, L, XL, 2XL', 'polyester', '6 months', 4),

('AC Milan Home Authentic 2025/26 JERSEY', 'jersey', 'football', 'acmilan',
'The 25/26 AC Milan Home Kit turns up the heat with iconic Red & Black, flame-detailed stripes, and a bold red crest. A modern take on the founders’ vision: red like flames, black like fear. Rossoneri, bring the heat.',
163.00, 'product_data/jerseys/acmilan/product1', '0.34 kg', '35 x 25 x 3 cm', 'XS, S, M, L, XL, 2XL', 'polyester', '6 months', 110),

('AC Milan x OFF-WHITE™ Replica Jersey Men', 'jersey', 'football', 'acmilan',
'From 1963 to forever. Co-created by PUMA, AC Milan, and Off-White™, this jersey honors Milan’s first European Cup triumph and a world driven by progress. With two alternative colorways and signature Off-White™ details, it celebrates unity and reminds us: change is unstoppable, so dream on.',
150.00, 'product_data/jerseys/acmilan/product2', '0.31 kg', '34 x 24 x 3 cm', 'M, L, XL, 2XL, 3XL', 'polyester', '6 months', 15),

('Bayern Muchen Authentic Away Jersey 25-26', 'jersey', 'football', 'bayern',
'The official Bayern München Authentic Away Jersey for the 2025/26 season combines cutting-edge performance with classic club pride. Featuring a gestickt (embroidered) Bayern crest and adidas logo, this jersey is crafted with atmungsaktiv (breathable) materials for ultimate comfort on and off the pitch. Designed for elite performance, it showcases premium adidas engineering and unmistakable Bayern style.',
130.00, 'product_data/jerseys/bayern/product1', '0.33 kg', '36 x 26 x 3 cm', 'S, M, L, XL, 2XL, 3XL', 'polyester', '6 months', 130),

('PSG Nike Home Stadium Shirt 2024-25', 'jersey', 'football', 'psg',
'The PSG Home Kit 2024/25 delivers a fresh take on the classic Hechter design, inspired by the urban art of Greater Paris. Featuring the iconic central red band framed by thin white brushstroke-style lines, this modern jersey captures the bold, disruptive spirit of a club known as the team of the new generation.',
85.00, 'product_data/jerseys/psg/product1', '0.28 kg', '34 x 24 x 3 cm', 'S, M, L, XL', 'polyester', '6 months', 120),

('Inter Milan Nike Home Match Jersey 2024/25', 'jersey', 'football', 'intermilan',
'For the first time, the second star shines above the logo on the 2024/25 Home Kit. Part of the Match collection, this jersey features Nike Dri-FIT ADV technology, combining lightweight, quick-drying, and breathable fabric for maximum comfort on the pitch. Made from recycled polyester and crafted with athlete-tested design, it’s the exact kit worn by the stars. Customize it with your favorite player’s name, number, and add Lega Serie A 2024/25 or Champions League sleeve patches.',
130.00, 'product_data/jerseys/intermilan/product1', '0.32 kg', '35 x 25 x 3 cm', 'M, L, XL, 2XL, 3XL', 'polyester', '6 months', 110),

('Borussia Dortmund 24/25 Home Jersey', 'jersey', 'football', 'dortmund',
'A true classic! The Borussia Dortmund 24/25 home shirt features a timeless design with black sleeves and four thin stripes across the iconic yellow base. On the back, bold black “Dortmund” lettering stands out, complemented by subtle stripes running from front to back. The club motto, Borussia verbindet (Borussia unites), is delicately placed on the collar, completing this elegant look.',
65.00, 'product_data/jerseys/dortmund/product1', '0.27 kg', '33 x 23 x 3 cm', 'S, M, L, XL', 'polyester', '6 months', 140);



INSERT INTO products (name, category, type, brand, description, price, path, weight, dimensions, size, fabric, warranty, quantity) VALUES
('Nike Mercurial Vapor 16 Academy ''Kylian Mbappé''', 'shoes', 'football', 'nike', 'Want to elevate your speed? These Academy Shoes feature an upgraded heel Air Zoom unit, delivering the explosive, propulsive feel you — and Kylian Mbappé — need to break past defenders. The most responsive Mercurial yet, built to help you control pace and tempo all match long.', 110, 'product_data/shoes/nike/product1', '220g (per shoe, size 42)', '30 x 10 x 12 cm', '39, 40, 41, 42, 43, 44, 45', 'Synthetic Flyknit upper with mesh', '12 months', 20),

('Nike Mercurial Superfly 10 Academy ''Kylian Mbappé''', 'shoes', 'football', 'nike', 'Looking to elevate your speed? These Academy Shoes feature an enhanced heel Air Zoom unit, giving you — and Kylian Mbappé — the explosive push to break through defenses. It’s the most responsive Mercurial we’ve ever created, built to help you control pace and tempo all match long.', 130, 'product_data/shoes/nike/product2', '230g (per shoe, size 42)', '31 x 10 x 13 cm', '39, 40, 41, 42, 43, 44, 45', 'Flyknit upper, synthetic overlays', '12 months', 25),

('Nike Phantom GX 2 Academy', 'shoes', 'football', 'nike', 'Looking to take your game to the next level? The Phantom GX 2 Academy helps put you in prime position of the goal, whether you''re the playmaker, assister or finisher. The rest is up to you. Created with goals in mind, NikeSkin covers the striking area of the shoe, while sticky traction helps guide your unscripted agility on the turf.', 100, 'product_data/shoes/nike/product3', '240g (per shoe, size 42)', '30 x 10 x 12 cm', '39, 40, 41, 42, 43, 44, 45', 'Synthetic NikeSkin upper, rubber outsole', '12 months', 90),

('Adidas F50 Elite Firm Ground Boots', 'shoes', 'football', 'adidas', 'Find your fast and express yourself on the pitch with adidas F50 boots, built for pure speed. Featuring a thin Fibertouch upper, Compression Fit Tunnel Tongue for secure lockdown, and Sprintweb 3D texture for close control, these Elite boots deliver. The Sprintframe 360 outsole adds spring and support, keeping you unstoppable on dry grass pitches.', 200, 'product_data/shoes/adidas/product1', '210g (per shoe, size 42)', '31 x 11 x 12 cm', '38, 39, 40, 41, 42, 43, 44, 45', 'Fibertouch synthetic upper, Sprintframe outsole', '12 months', 70),

('Adidas Predator League Turf Boots', 'shoes', 'football', 'adidas', 'Discover the difference between hoping to score and knowing you will with adidas Predator boots, built for goals. These League boots feature a Hybridfeel upper with all-over 3D texture and grippy Strikescale fins for precise ball control. A lug rubber outsole ensures stability on artificial turf pitches.', 95, 'product_data/shoes/adidas/product2', '260g (per shoe, size 42)', '30 x 11 x 12 cm', '38, 39, 40, 41, 42, 43, 44, 45', 'Hybridfeel synthetic upper, rubber outsole', '12 months', 100),

('Adidas F50 League Firm/Multi-Ground Boots', 'shoes', 'football', 'adidas', 'Push your pace to the limit with lightweight adidas F50 boots, engineered for pure speed. Featuring an eye-catching Sprintgrid print, the Fiberskin upper and adaptive Tunnel Tongue provide a secure fit. Underfoot, the Sprintplate 360 outsole delivers extra acceleration on firm ground and artificial grass. Made with at least 20% recycled materials to help reduce waste and environmental impact.', 90, 'product_data/shoes/adidas/product3', '220g (per shoe, size 42)', '31 x 11 x 12 cm', '38, 39, 40, 41, 42, 43, 44, 45', 'Fiberskin synthetic upper, Sprintplate outsole', '12 months', 90),

('Adizero Evo SL Men', 'shoes', 'running', 'adidas', 'Feel the rush of speed in the Adizero Evo SL. Inspired by the record-breaking innovation of the Adizero Pro Evo 1, this shoe blends race-day performance with everyday style. Featuring LIGHTSTRIKE PRO foam for responsive cushioning and energy return, it’s built to move—whether you are running or just living life in the fast lane.', 190, 'product_data/shoes/adidas/product4', '180g (per shoe, size 42)', '29 x 10 x 11 cm', '40, 41, 42, 43, 44, 45, 46', 'Primeknit upper, LIGHTSTRIKE PRO foam midsole', '12 months', 60),

('Adidas Ultraboost 5', 'shoes', 'running', 'adidas', 'The Ultraboost 5 is built for your most energized run yet. Featuring Light BOOST V2—adidas’ highest energy return cushioning—it delivers unmatched comfort with less weight. A PRIMEKNIT upper adapts to your foot for a perfect fit, while the moulded heel support and Torsion System provide stability and smooth transitions. Finished with a Continental™ outsole for superior grip, this is performance at its peak.', 200, 'product_data/shoes/adidas/product5', '310g (per shoe, size 42)', '30 x 11 x 12 cm', '40, 41, 42, 43, 44, 45, 46', 'Primeknit upper, BOOST midsole, Continental rubber outsole', '12 months', 70);


INSERT INTO products (name, category, type, brand, description, price, path, weight, dimensions, size, fabric, warranty, quantity) VALUES
('Manchester United x adidas Chinese New Year Jacket Black', 'jacket', 'football', 'manchesterunited', 'Button up this loose-fitting Manchester United jacket to celebrate Chinese New Year in style. Featuring a golden crest and the iconic devil symbol, it’s a bold way to show your club pride during the festivities. Made with a smooth plain weave shell and soft single jersey lining, this adidas jacket offers all-day comfort. Designed with UNITEFIT, an all-gender fit system created for diverse sizes and shapes, it’s perfect for everyone.', 200, 'product_data/jackets/machesterunited/product1', 850, '60x40x5 cm', 'XS, S, M, L, XL, 2XL, 3XL', 'plain weave shell, single jersey lining', '12 months', 120),

('Manchester United Originals Track Top', 'jacket', 'football', 'manchesterunited', 'An ode to football history, this Manchester United track top blends iconic club details with adidas archive-inspired style. Its loose fit and smooth fabric keep you comfortable while you represent. The chest features a classic Trefoil alongside a red devil badge, capturing the spirit of the beautiful game. Made with at least 70% recycled materials, it helps reduce waste and environmental impact.', 160, 'product_data/jackets/machesterunited/product2', 700, '58x38x4 cm', 'S, M, L, XL, 2XL', 'polyester blend with recycled content', '12 months', 150),

('AC Milan X Off-White- Varsity Jacket', 'jacket', 'football', 'acmilan', 'Rooted in AC Milan’s history, this collection blends the club’s iconic devil mascot and classic red and black with vintage football and “125” anniversary graphics, accented in gold to honor its legacy. Featuring Off-White™ silhouettes for adults and kids—including varsity jackets, hoodies, and tees—plus accessories like caps, scarves, luggage, and socks. Entirely conceptualized and designed in Milan, the varsity jacket is Made in Italy with premium craftsmanship and gold-satin embroidery, celebrating both AC Milan and Off-White™ heritage.', 2950, 'product_data/jackets/acmilan/product1', 1200, '65x45x6 cm', 'M, L, XL, 2XL', 'cotton blend with satin embroidery', '24 months', 40),

('Real Madrid Adidas DNA Track Top 24/25 White', 'jacket', 'football', 'realmadrid', 'Comfort meets fandom in this adidas training jacket, perfect for showing your Real Madrid pride at the stadium or from home. Ribbed details and soft jersey fabric deliver a cozy fit, while the embroidered club logo and classic white-and-blue colors make your allegiance clear.', 100, 'product_data/jackets/realmadrid/product1', 750, '59x39x4 cm', 'S, M, L, XL, 2XL', 'jersey fabric with ribbed trims', '12 months', 180),

('Inter Milan Nike Pre-Match Champions League Anthem Jacket', 'jacket', 'football', 'intermilan', 'The pre-match INTER anthem jacket is the same one worn by your favourite players when they take to the pitch during big Champions League nights. Perfect to wear over your jersey, it provides ideal warmth as you cheer on the Nerazzurri.', 130, 'product_data/jackets/intermilan/product1', 800, '60x40x5 cm', 'S, M, L, XL, 2XL, 3XL', 'polyester with mesh lining', '12 months', 140),

('PSG x Jordan Wings Cashmere and Leather Varsity Jacket - Blue Void', 'jacket', 'football', 'psg', 'Made in Italy, the Jordan Wings x PSG Varsity Jacket blends premium materials with timeless sport style. Featuring a cashmere-blend body, leather shoulder panels in a wing-inspired design, and an allover embroidered ICI C’EST PARIS monogram, it’s finished with a matching satin lining and ribbed cuffs and collar. Available in Blue Void, this jacket delivers a truly standout look.', 2100, 'product_data/jackets/psg/product1', 1400, '66x46x6 cm', 'M, L, XL', 'cashmere blend with leather panels', '24 months', 50);

INSERT INTO products (name, category, type, brand, description, price, path, weight, dimensions, size, fabric, warranty, quantity) VALUES
('Manchester United x New Era Bar Stripe Bucket Hat', 'accessories', 'hat', 'manchesterunited', 'Show your United pride with this official bucket hat, inspired by the design gifted at the 22/23 FA Cup final and revived by fans during the 23/24 celebrations. Featuring bar stripes in fan flag colours and an embroidered devil on the visor, it’s a timeless accessory for true supporters. Made from soft cotton twill for all-day comfort.', 30, 'product_data/accessories/manchesterunited/product1', 150, '30x30x15 cm', 'S, M, L', 'cotton twill', '12 months', 200),

('Manchester United Bucket Hat Fred the Red Plush Red', 'accessories', 'toy', 'manchesterunited', 'Perfect for young fans, this Fred the Red plush is a fun matchday companion or a charming addition to any United-themed room. Dressed in a bucket hat and red devil tee, this mascot toy sports a classic fan look—bringing Manchester United style and spirit home. A great gift for supporters of all ages.', 25, 'product_data/accessories/manchesterunited/product2', 300, '20x15x15 cm', 'One Size', 'plush fabric', '12 months', 150),

('Manchester United Bar Scarf Gift Box Black', 'accessories', 'scarf', 'manchesterunited', 'A stylish gift for any Manchester United fan, this official scarf pairs effortlessly with any outfit while adding a subtle nod to the club. Featuring a sleek black design with white and gold stripes, it’s finished with gold embroidered devils to show your allegiance. Packaged in a premium gift box, it’s the perfect present for the Reds in your life.', 20, 'product_data/accessories/manchesterunited/product3', 250, '180x25x5 cm', 'One Size', 'acrylic blend', '12 months', 250),

('Manchester United BRXLZ Large Old Trafford Stadium', 'accessories', 'toy', 'manchesterunited', 'Bring Old Trafford to life with this BRXLZ stadium kit, a must-have for any Manchester United fan. Recreate the iconic Sir Alex Ferguson Stand and experience the magic of the Theatre of Dreams piece by piece. Perfect for model builders or newcomers alike, this detailed kit makes a great gift—and a proud display of your United loyalty once complete.', 110, 'product_data/accessories/manchesterunited/product4', 1200, '35x30x15 cm', 'One Size', 'plastic bricks', '12 months', 100),

('Manchester United Size 5 Illustrated Football White', 'accessories', 'ball', 'manchesterunited', 'Add a distinctive piece to your collection with this official Manchester United illustrated football. Featuring detailed line drawings by Manchester artist Izzy Winter, the design showcases iconic views of Old Trafford, the city, and club legends. A size 5 ball, it’s perfect as a display piece or a thoughtful keepsake for any devoted fan.', 100, 'product_data/accessories/manchesterunited/product5', 450, '22x22x22 cm', 'Size 5', 'synthetic leather', '12 months', 180),

('Manchester United x New Era Kids 9Forty Core Cap', 'accessories', 'hat', 'manchesterunited', 'The perfect finishing touch for any young fan’s outfit, this classic kids’ baseball cap features the iconic Manchester United crest for a bold show of team pride. Made from breathable cotton twill with a low crown and adjustable D-ring closure, it offers all-day comfort and effortless summer style. A must-have for every junior Red.', 26, 'product_data/accessories/manchesterunited/product6', 120, '28x28x12 cm', 'Kids', 'cotton twill', '12 months', 220),

('Wayne Rooney, Teenage Kicks Book', 'accessories', 'book', 'manchesterunited', 'Relive the rise of a football icon in Wayne Rooney: Teenage Kicks. From his early days at Everton to his record-breaking years at Manchester United, this biography explores the key moments of Rooney’s legendary career. Packed with era-defining highlights and behind-the-scenes stories, it’s a must-read for fans eager to learn more about one of football’s greatest talents—a perfect gift for any United supporter.', 26, 'product_data/accessories/manchesterunited/product7', 350, '20x13x3 cm', 'One Size', 'paper', 'No warranty', 300),

('Cushioned Crew Socks 3 Pairs', 'accessories', 'socks', 'adidas', 'From daily workouts to game day, these adidas crew-length socks are built for comfort and support. With targeted arch compression and cushioning at the heels and toes, they reduce pressure so you can stay focused on your performance—whether you''re training, lifting, or playing.', 10, 'product_data/accessories/adidas/product1', 90, '25x10x5 cm', 'S, M, L', 'cotton blend', '6 months', 500),

('Classic Badge Of Sport Backpack', 'accessories', 'bag', 'adidas', 'The backpack is back—and better than ever. This adidas classic blends style and function, with space for everything from your laptop to your gym gear. A side pocket keeps your water bottle within easy reach, while its clean design makes it a go-to for daily use.', 25, 'product_data/accessories/adidas/product2', 900, '45x30x15 cm', 'One Size', 'polyester', '12 months', 150),

('Predator Training Goalkeeper Gloves', 'accessories', 'gloves', 'adidas', 'Sharpen your skills with adidas Predator Training goalkeeper gloves. Designed for reliable grip and comfort, they feature a cushioned Soft Grip latex palm, flexible backhand, and a roomy finger cut for confident saves. An adjustable elastic bandage strap ensures a secure, stable fit so you can focus on every shot.', 38, 'product_data/accessories/adidas/product3', 300, '25x15x5 cm', 'S, M, L', 'latex and polyester', '12 months', 180),

('Outline Trefoil Shoulder Bag', 'accessories', 'bag', 'adidas', 'Designed to complement your everyday look, this adidas shoulder bag offers sleek, effortless style. Featuring a clean, minimalist design with an embossed Trefoil logo and refined outline stitching, it holds your essentials with ease. The padded shoulder strap ensures all-day comfort wherever you go.', 55, 'product_data/accessories/adidas/product4', 600, '35x20x10 cm', 'One Size', 'polyester', '12 months', 120);




