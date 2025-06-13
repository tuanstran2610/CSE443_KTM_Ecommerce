using CSE443_KTM_Ecommerce.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CSE443_KTM_Ecommerce.Data
{
    public class KTMDbContext : IdentityDbContext<
        User,                          // User class
        Role,                          // Role class
        int,                           // Primary key type
        IdentityUserClaim<int>,        // User claims
        IdentityUserRole<int>,         // User-Role link
        IdentityUserLogin<int>,        // External logins
        IdentityRoleClaim<int>,        // Role claims
        IdentityUserToken<int>>        // User tokens
    {

        public KTMDbContext(DbContextOptions<KTMDbContext> options) : base(options)
        { }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductDiscount> ProductDiscounts { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Delivery> Deliveries { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships and other settings here if needed
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Role>().HasData(
               new Role { Id = 1, Name = "CUSTOMER" },
               new Role { Id = 2, Name = "ADMIN" },
               new Role { Id = 3, Name = "MANAGER" });

            modelBuilder.Entity<Delivery>().HasData(
                new Delivery { Id = 1, Name = "Standard Delivery", Description = "Delivered in 3–5 days", DeliveryFees = 2.99M },
                new Delivery { Id = 2, Name = "Express Delivery", Description = "Delivered in 1–2 days", DeliveryFees = 5.99M },
               new Delivery { Id = 3, Name = "Pickup In-Store", Description = "Pick up from store for free", DeliveryFees = 1.02M }
                );
            
           
            var adminUser = new User
            {
                Id = 999,
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@example.com",
                NormalizedEmail = "ADMIN@EXAMPLE.COM",
                EmailConfirmed = true,
                SecurityStamp = "STATIC-SECURITY-STAMP",
                ConcurrencyStamp = "STATIC-CONCURRENCY-STAMP",
                FullName = "Super Admin",
                Address = "Admin Address",
                CreatedAt = new DateTime(2024, 01, 01),
                PasswordHash = "AQAAAAIAAYagAAAAEGlTlHiVUEOUM7qZpWBhE+czTE+iWAsmjeJ5G17QcKxXGcFesY1oqdIdS7Ezs8CGbQ==" //Admin@123
            };

            modelBuilder.Entity<User>().HasData(adminUser);

            modelBuilder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int>
            {
                UserId = 1000,
                RoleId = 2
            });


            modelBuilder.Entity<ProductType>().HasData(
                    new ProductType { 
                    Id = 1,
                    Name = "Football"
                    },
                    new ProductType
                    {
                        Id = 2,
                        Name = "Hat"
                    },
                    new ProductType
                    {
                        Id = 3,
                        Name = "Toy"
                    },
                    new ProductType
                    {
                        Id = 4,
                        Name = "Scarf"
                    },
                    new ProductType
                    {
                        Id = 5,
                        Name = "Book/Magazines"
                    },
                     new ProductType
                     {
                         Id = 6,
                         Name = "Gloves"
                     },
                      new ProductType
                      {
                          Id = 7,
                          Name = "Bag"
                      },
                       new ProductType
                       {
                           Id = 8,
                           Name = "Running"
                      }
                );
            modelBuilder.Entity<Category>().HasData(
               new Category
               {
                   Id =1, 
                   Name = "Jersey"
               },
                new Category
                {
                    Id = 2,
                    Name = "Shoes"
                },
                 new Category
                 {
                     Id = 3,
                     Name = "Jacket"
                 },
                  new Category
                  {
                      Id = 4,
                      Name = "Accessories"
                  }
            );
            modelBuilder.Entity<Product>().HasData(
                  // Jerseys
                  new Product
                  {
                      Id = 1,
                      Name = "Manchester United x adidas Bring Back 1991 Away 7 Printed Jersey White",
                      Description = "Captain Marvel’s jersey: number 7 for Bryan Robson, United’s longest-serving captain (1982–1994) with 461 appearances. This one-to-one adidas remake celebrates the 1991 Cup Winners’ Cup triumph, featuring detailed cuffs, collar, subtle patterns, and the special cup final badge in classic white away colors.",
                      Brand = "manchesterunited",
                      Quantity = 25,
                      Price = 160.00m,
                      Dimensions = "36 x 26 x 3 cm",
                      Weight = "0.32 kg",
                      Size = "XS, S, M, L, XL, 2XL, 3XL",
                      Fabric = "jacquard",
                      Warranty = "6 months",
                      CategoryId = 1, // 'jersey' (originally ProductTypeId)
                      ProductTypeId = 1 // 'football' (originally CategoryId)
                  },
                  new Product
                  {
                      Id = 2,
                      Name = "Manchester United 1992-94 Retro Home Shirt Red",
                      Description = "Relive the early Premier League glory with this Manchester United retro shirt, worn in the 92/93 and 93/94 title-winning seasons. Featuring bold United red and a white contrast collar, it’s perfect for fans celebrating club legends or adding a stylish 90s vibe to their look.",
                      Brand = "manchesterunited",
                      Quantity = 50,
                      Price = 100.00m,
                      Dimensions = "35 x 25 x 3 cm",
                      Weight = "0.30 kg",
                      Size = "S, M, L, XL, 2XL",
                      Fabric = "polyester",
                      Warranty = "6 months",
                      CategoryId = 1, // 'jersey'
                      ProductTypeId = 1 // 'football'
                  },
                  new Product
                  {
                      Id = 3,
                      Name = "Manchester United 24/25 Home Jersey",
                      Description = "Manchester United at Old Trafford: beloved by fans, respected by rivals. The 24/25 home jersey stands out with bright red side inserts and a subtle gradient design. Made for supporters, it features adidas AEROREADY, an embroidered badge, and 100% recycled materials to help reduce waste and environmental impact.",
                      Brand = "manchesterunited",
                      Quantity = 130,
                      Price = 80.00m,
                      Dimensions = "34 x 24 x 3 cm",
                      Weight = "0.28 kg",
                      Size = "M, L, XL, 2XL, 3XL",
                      Fabric = "polyester",
                      Warranty = "6 months",
                      CategoryId = 1, // 'jersey'
                      ProductTypeId = 1 // 'football'
                  },
                  new Product
                  {
                      Id = 4,
                      Name = "Real Madrid Home Bring Back 99/00 Jersey White",
                      Description = "Relive Real Madrid’s 99/00 European triumph with this one-to-one adidas replica of the iconic home jersey. Featuring a Henley collar, classic loose fit, historic TEKA sponsor, and era-specific woven badge, it’s a perfect piece for devoted fans and football fashion lovers.",
                      Brand = "realmadrid",
                      Quantity = 30,
                      Price = 140.00m,
                      Dimensions = "35 x 25 x 3 cm",
                      Weight = "0.31 kg",
                      Size = "XS, S, M, L, XL",
                      Fabric = "polyester",
                      Warranty = "6 months",
                      CategoryId = 1, // 'jersey'
                      ProductTypeId = 1 // 'football'
                  },
                  new Product
                  {
                      Id = 5,
                      Name = "Real Madrid Home Authentic Shirt 24/25 White",
                      Description = "Inspired by Madrid’s “chulapo” outfits, this Real Madrid home jersey features a stylish houndstooth pattern, ventilating HEAT.RDY, and a heat-applied badge. Designed for on-pitch performance, it’s made from 100% recycled materials to help reduce waste and environmental impact.",
                      Brand = "realmadrid",
                      Quantity = 110,
                      Price = 100.00m,
                      Dimensions = "34 x 24 x 3 cm",
                      Weight = "0.29 kg",
                      Size = "S, M, L, XL, 2XL",
                      Fabric = "polyester",
                      Warranty = "6 months",
                      CategoryId = 1, // 'jersey'
                      ProductTypeId = 1 // 'football'
                  },
                  new Product
                  {
                      Id = 6,
                      Name = "CJ X Nike X FC Barcelona Retro 2000/01 Home Skeleton Jersey",
                      Description = "FC Barcelona 2000/01 Retro Nike Jersey: features commemorative collab woven label, embroidered Swoosh and retro FCB crest, printed skeleton graphic on front, plus Cactus Jack spray logo, CJ classic logo, #2, and Barça motif on back.",
                      Brand = "barcelona",
                      Quantity = 5,
                      Price = 200.00m,
                      Dimensions = "37 x 27 x 3 cm",
                      Weight = "0.35 kg",
                      Size = "XS, S, M, L, XL, 2XL, 3XL",
                      Fabric = "polyester",
                      Warranty = "6 months",
                      CategoryId = 1, // 'jersey'
                      ProductTypeId = 1 // 'football'
                  },
                  new Product
                  {
                      Id = 7,
                      Name = "FC Barcelona 2024/25 Match Home X Cactus Jack Jersey",
                      Description = "Limited edition of 1,899, this CJ x Nike x FCB men’s athletic-fit jersey comes in a custom collector’s box with a numbered certificate of authenticity. Made with Nike Dri-FIT ADV performance material, it features Cactus Jack, Nike, and FCB logo details.",
                      Brand = "barcelona",
                      Quantity = 4,
                      Price = 150.00m,
                      Dimensions = "36 x 26 x 3 cm",
                      Weight = "0.33 kg",
                      Size = "S, M, L, XL, 2XL",
                      Fabric = "polyester",
                      Warranty = "6 months",
                      CategoryId = 1, // 'jersey'
                      ProductTypeId = 1 // 'football'
                  },
                  new Product
                  {
                      Id = 8,
                      Name = "AC Milan Home Authentic 2025/26 JERSEY",
                      Description = "The 25/26 AC Milan Home Kit turns up the heat with iconic Red & Black, flame-detailed stripes, and a bold red crest. A modern take on the founders’ vision: red like flames, black like fear. Rossoneri, bring the heat.",
                      Brand = "acmilan",
                      Quantity = 110,
                      Price = 163.00m,
                      Dimensions = "35 x 25 x 3 cm",
                      Weight = "0.34 kg",
                      Size = "XS, S, M, L, XL, 2XL",
                      Fabric = "polyester",
                      Warranty = "6 months",
                      CategoryId = 1, // 'jersey'
                      ProductTypeId = 1 // 'football'
                  },
                  new Product
                  {
                      Id = 9,
                      Name = "AC Milan x OFF-WHITE™ Replica Jersey Men",
                      Description = "From 1963 to forever. Co-created by PUMA, AC Milan, and Off-White™, this jersey honors Milan’s first European Cup triumph and a world driven by progress. With two alternative colorways and signature Off-White™ details, it celebrates unity and reminds us: change is unstoppable, so dream on.",
                      Brand = "acmilan",
                      Quantity = 15,
                      Price = 150.00m,
                      Dimensions = "34 x 24 x 3 cm",
                      Weight = "0.31 kg",
                      Size = "M, L, XL, 2XL, 3XL",
                      Fabric = "polyester",
                      Warranty = "6 months",
                      CategoryId = 1, // 'jersey'
                      ProductTypeId = 1 // 'football'
                  },
                  new Product
                  {
                      Id = 10,
                      Name = "Bayern Muchen Authentic Away Jersey 25-26",
                      Description = "The official Bayern München Authentic Away Jersey for the 2025/26 season combines cutting-edge performance with classic club pride. Featuring a gestickt (embroidered) Bayern crest and adidas logo, this jersey is crafted with atmungsaktiv (breathable) materials for ultimate comfort on and off the pitch. Designed for elite performance, it showcases premium adidas engineering and unmistakable Bayern style.",
                      Brand = "bayern",
                      Quantity = 130,
                      Price = 130.00m,
                      Dimensions = "36 x 26 x 3 cm",
                      Weight = "0.33 kg",
                      Size = "S, M, L, XL, 2XL, 3XL",
                      Fabric = "polyester",
                      Warranty = "6 months",
                      CategoryId = 1, // 'jersey'
                      ProductTypeId = 1 // 'football'
                  },
                  new Product
                  {
                      Id = 11,
                      Name = "PSG Nike Home Stadium Shirt 2024-25",
                      Description = "The PSG Home Kit 2024/25 delivers a fresh take on the classic Hechter design, inspired by the urban art of Greater Paris. Featuring the iconic central red band framed by thin white brushstroke-style lines, this modern jersey captures the bold, disruptive spirit of a club known as the team of the new generation.",
                      Brand = "psg",
                      Quantity = 120,
                      Price = 85.00m,
                      Dimensions = "34 x 24 x 3 cm",
                      Weight = "0.28 kg",
                      Size = "S, M, L, XL",
                      Fabric = "polyester",
                      Warranty = "6 months",
                      CategoryId = 1, // 'jersey'
                      ProductTypeId = 1 // 'football'
                  },
                  new Product
                  {
                      Id = 12,
                      Name = "Inter Milan Nike Home Match Jersey 2024/25",
                      Description = "For the first time, the second star shines above the logo on the 2024/25 Home Kit. Part of the Match collection, this jersey features Nike Dri-FIT ADV technology, combining lightweight, quick-drying, and breathable fabric for maximum comfort on the pitch. Made from recycled polyester and crafted with athlete-tested design, it’s the exact kit worn by the stars. Customize it with your favorite player’s name, number, and add Lega Serie A 2024/25 or Champions League sleeve patches.",
                      Brand = "intermilan",
                      Quantity = 110,
                      Price = 130.00m,
                      Dimensions = "35 x 25 x 3 cm",
                      Weight = "0.32 kg",
                      Size = "M, L, XL, 2XL, 3XL",
                      Fabric = "polyester",
                      Warranty = "6 months",
                      CategoryId = 1, // 'jersey'
                      ProductTypeId = 1 // 'football'
                  },
                  new Product
                  {
                      Id = 13,
                      Name = "Borussia Dortmund 24/25 Home Jersey",
                      Description = "A true classic! The Borussia Dortmund 24/25 home shirt features a timeless design with black sleeves and four thin stripes across the iconic yellow base. On the back, bold black “Dortmund” lettering stands out, complemented by subtle stripes running from front to back. The club motto, Borussia verbindet (Borussia unites), is delicately placed on the collar, completing this elegant look.",
                      Brand = "dortmund",
                      Quantity = 140,
                      Price = 65.00m,
                      Dimensions = "33 x 23 x 3 cm",
                      Weight = "0.27 kg",
                      Size = "S, M, L, XL",
                      Fabric = "polyester",
                      Warranty = "6 months",
                      CategoryId = 1, // 'jersey'
                      ProductTypeId = 1 // 'football'
                  },
                  // Shoes
                  new Product
                  {
                      Id = 14,
                      Name = "Nike Mercurial Vapor 16 Academy 'Kylian Mbappé'",
                      Description = "Want to elevate your speed? These Academy Shoes feature an upgraded heel Air Zoom unit, delivering the explosive, propulsive feel you — and Kylian Mbappé — need to break past defenders. The most responsive Mercurial yet, built to help you control pace and tempo all match long.",
                      Brand = "nike",
                      Quantity = 20,
                      Price = 110.00m,
                      Dimensions = "30 x 10 x 12 cm",
                      Weight = "220g (per shoe, size 42)",
                      Size = "39, 40, 41, 42, 43, 44, 45",
                      Fabric = "Synthetic Flyknit upper with mesh",
                      Warranty = "12 months",
                      CategoryId = 2, // 'shoes' (originally ProductTypeId)
                      ProductTypeId = 1 // 'football' (originally CategoryId)
                  },
                  new Product
                  {
                      Id = 15,
                      Name = "Nike Mercurial Superfly 10 Academy 'Kylian Mbappé'",
                      Description = "Looking to elevate your speed? These Academy Shoes feature an enhanced heel Air Zoom unit, giving you — and Kylian Mbappé — the explosive push to break through defenses. It’s the most responsive Mercurial we’ve ever created, built to help you control pace and tempo all match long.",
                      Brand = "nike",
                      Quantity = 18,
                      Price = 130.00m,
                      Dimensions = "31 x 10 x 13 cm",
                      Weight = "230g (per shoe, size 42)",
                      Size = "39, 40, 41, 42, 43, 44, 45",
                      Fabric = "Flyknit upper, synthetic overlays",
                      Warranty = "12 months",
                      CategoryId = 2, // 'shoes'
                      ProductTypeId = 1 // 'football'
                  },
                  new Product
                  {
                      Id = 16,
                      Name = "Nike Phantom GX 2 Academy",
                      Description = "Looking to take your game to the next level? The Phantom GX 2 Academy helps put you in prime position of the goal, whether you're the playmaker, assister or finisher. The rest is up to you. Created with goals in mind, NikeSkin covers the striking area of the shoe, while sticky traction helps guide your unscripted agility on the turf.",
                      Brand = "nike",
                      Quantity = 90,
                      Price = 100.00m,
                      Dimensions = "30 x 10 x 12 cm",
                      Weight = "240g (per shoe, size 42)",
                      Size = "39, 40, 41, 42, 43, 44, 45",
                      Fabric = "Synthetic NikeSkin upper, rubber outsole",
                      Warranty = "12 months",
                      CategoryId = 2, // 'shoes'
                      ProductTypeId = 1 // 'football'
                  },
                  new Product
                  {
                      Id = 17,
                      Name = "Adidas F50 Elite Firm Ground Boots",
                      Description = "Find your fast and express yourself on the pitch with adidas F50 boots, built for pure speed. Featuring a thin Fibertouch upper, Compression Fit Tunnel Tongue for secure lockdown, and Sprintweb 3D texture for close control, these Elite boots deliver. The Sprintframe 360 outsole adds spring and support, keeping you unstoppable on dry grass pitches.",
                      Brand = "adidas",
                      Quantity = 70,
                      Price = 200.00m,
                      Dimensions = "31 x 11 x 12 cm",
                      Weight = "210g (per shoe, size 42)",
                      Size = "38, 39, 40, 41, 42, 43, 44, 45",
                      Fabric = "Fibertouch synthetic upper, Sprintframe outsole",
                      Warranty = "12 months",
                      CategoryId = 2, // 'shoes'
                      ProductTypeId = 1 // 'football'
                  },
                  new Product
                  {
                      Id = 18,
                      Name = "Adidas Predator League Turf Boots",
                      Description = "Discover the difference between hoping to score and knowing you will with adidas Predator boots, built for goals. These League boots feature a Hybridfeel upper with all-over 3D texture and grippy Strikescale fins for precise ball control. A lug rubber outsole ensures stability on artificial turf pitches.",
                      Brand = "adidas",
                      Quantity = 100,
                      Price = 95.00m,
                      Dimensions = "30 x 11 x 12 cm",
                      Weight = "260g (per shoe, size 42)",
                      Size = "38, 39, 40, 41, 42, 43, 44, 45",
                      Fabric = "Hybridfeel synthetic upper, rubber outsole",
                      Warranty = "12 months",
                      CategoryId = 2, // 'shoes'
                      ProductTypeId = 1 // 'football'
                  },
                  new Product
                  {
                      Id = 19,
                      Name = "Adidas F50 League Firm/Multi-Ground Boots",
                      Description = "Push your pace to the limit with lightweight adidas F50 boots, engineered for pure speed. Featuring an eye-catching Sprintgrid print, the Fiberskin upper and adaptive Tunnel Tongue provide a secure fit. Underfoot, the Sprintplate 360 outsole delivers extra acceleration on firm ground and artificial grass. Made with at least 20% recycled materials to help reduce waste and environmental impact.",
                      Brand = "adidas",
                      Quantity = 90,
                      Price = 90.00m,
                      Dimensions = "31 x 11 x 12 cm",
                      Weight = "220g (per shoe, size 42)",
                      Size = "38, 39, 40, 41, 42, 43, 44, 45",
                      Fabric = "Fiberskin synthetic upper, Sprintplate outsole",
                      Warranty = "12 months",
                      CategoryId = 2, // 'shoes'
                      ProductTypeId = 1 // 'football'
                  },
                  new Product
                  {
                      Id = 20,
                      Name = "Adizero Evo SL Men",
                      Description = "Feel the rush of speed in the Adizero Evo SL. Inspired by the record-breaking innovation of the Adizero Pro Evo 1, this shoe blends race-day performance with everyday style. Featuring LIGHTSTRIKE PRO foam for responsive cushioning and energy return, it’s built to move—whether you are running or just living life in the fast lane.",
                      Brand = "adidas",
                      Quantity = 60,
                      Price = 190.00m,
                      Dimensions = "29 x 10 x 11 cm",
                      Weight = "180g (per shoe, size 42)",
                      Size = "40, 41, 42, 43, 44, 45, 46",
                      Fabric = "Primeknit upper, LIGHTSTRIKE PRO foam midsole",
                      Warranty = "12 months",
                      CategoryId = 2, // 'shoes' (originally ProductTypeId)
                      ProductTypeId = 8 // 'running' (originally CategoryId)
                  },
                  new Product
                  {
                      Id = 21,
                      Name = "Adidas Ultraboost 5",
                      Description = "The Ultraboost 5 is built for your most energized run yet. Featuring Light BOOST V2—adidas’ highest energy return cushioning—it delivers unmatched comfort with less weight. A PRIMEKNIT upper adapts to your foot for a perfect fit, while the moulded heel support and Torsion System provide stability and smooth transitions. Finished with a Continental™ outsole for superior grip, this is performance at its peak.",
                      Brand = "adidas",
                      Quantity = 70,
                      Price = 200.00m,
                      Dimensions = "30 x 11 x 12 cm",
                      Weight = "310g (per shoe, size 42)",
                      Size = "40, 41, 42, 43, 44, 45, 46",
                      Fabric = "Primeknit upper, BOOST midsole, Continental rubber outsole",
                      Warranty = "12 months",
                      CategoryId = 2, // 'shoes'
                      ProductTypeId = 8 // 'running'
                  },
                  // Jackets
                  new Product
                  {
                      Id = 22,
                      Name = "Manchester United x adidas Chinese New Year Jacket Black",
                      Description = "Button up this loose-fitting Manchester United jacket to celebrate Chinese New Year in style. Featuring a golden crest and the iconic devil symbol, it’s a bold way to show your club pride during the festivities. Made with a smooth plain weave shell and soft single jersey lining, this adidas jacket offers all-day comfort. Designed with UNITEFIT, an all-gender fit system created for diverse sizes and shapes, it’s perfect for everyone.",
                      Brand = "manchesterunited",
                      Quantity = 120,
                      Price = 200.00m,
                      Dimensions = "60x40x5 cm",
                      Weight = "850",
                      Size = "XS, S, M, L, XL, 2XL, 3XL",
                      Fabric = "plain weave shell, single jersey lining",
                      Warranty = "12 months",
                      CategoryId = 3, // 'jacket' (originally ProductTypeId)
                      ProductTypeId = 1 // 'football' (originally CategoryId)
                  },
                  new Product
                  {
                      Id = 23,
                      Name = "Manchester United Originals Track Top",
                      Description = "An ode to football history, this Manchester United track top blends iconic club details with adidas archive-inspired style. Its loose fit and smooth fabric keep you comfortable while you represent. The chest features a classic Trefoil alongside a red devil badge, capturing the spirit of the beautiful game. Made with at least 70% recycled materials, it helps reduce waste and environmental impact.",
                      Brand = "manchesterunited",
                      Quantity = 150,
                      Price = 160.00m,
                      Dimensions = "58x38x4 cm",
                      Weight = "700",
                      Size = "S, M, L, XL, 2XL",
                      Fabric = "polyester blend with recycled content",
                      Warranty = "12 months",
                      CategoryId = 3, // 'jacket'
                      ProductTypeId = 1 // 'football'
                  },
                  new Product
                  {
                      Id = 24,
                      Name = "AC Milan X Off-White- Varsity Jacket",
                      Description = "Rooted in AC Milan’s history, this collection blends the club’s iconic devil mascot and classic red and black with vintage football and “125” anniversary graphics, accented in gold to honor its legacy. Featuring Off-White™ silhouettes for adults and kids—including varsity jackets, hoodies, and tees—plus accessories like caps, scarves, luggage, and socks. Entirely conceptualized and designed in Milan, the varsity jacket is Made in Italy with premium craftsmanship and gold-satin embroidery, celebrating both AC Milan and Off-White™ heritage.",
                      Brand = "acmilan",
                      Quantity = 40,
                      Price = 2950.00m,
                      Dimensions = "65x45x6 cm",
                      Weight = "1200",
                      Size = "M, L, XL, 2XL",
                      Fabric = "cotton blend with satin embroidery",
                      Warranty = "24 months",
                      CategoryId = 3, // 'jacket'
                      ProductTypeId = 1 // 'football'
                  },
                  new Product
                  {
                      Id = 25,
                      Name = "Real Madrid Adidas DNA Track Top 24/25 White",
                      Description = "Comfort meets fandom in this adidas training jacket, perfect for showing your Real Madrid pride at the stadium or from home. Ribbed details and soft jersey fabric deliver a cozy fit, while the embroidered club logo and classic white-and-blue colors make your allegiance clear.",
                      Brand = "realmadrid",
                      Quantity = 180,
                      Price = 100.00m,
                      Dimensions = "59x39x4 cm",
                      Weight = "750",
                      Size = "S, M, L, XL, 2XL",
                      Fabric = "jersey fabric with ribbed trims",
                      Warranty = "12 months",
                      CategoryId = 3, // 'jacket'
                      ProductTypeId = 1 // 'football'
                  },
                  new Product
                  {
                      Id = 26,
                      Name = "Inter Milan Nike Pre-Match Champions League Anthem Jacket",
                      Description = "The pre-match INTER anthem jacket is the same one worn by your favourite players when they take to the pitch during big Champions League nights. Perfect to wear over your jersey, it provides ideal warmth as you cheer on the Nerazzurri.",
                      Brand = "intermilan",
                      Quantity = 140,
                      Price = 130.00m,
                      Dimensions = "60x40x5 cm",
                      Weight = "800",
                      Size = "S, M, L, XL, 2XL, 3XL",
                      Fabric = "polyester with mesh lining",
                      Warranty = "12 months",
                      CategoryId = 3, // 'jacket'
                      ProductTypeId = 1 // 'football'
                  },
                  new Product
                  {
                      Id = 27,
                      Name = "PSG x Jordan Wings Cashmere and Leather Varsity Jacket - Blue Void",
                      Description = "Made in Italy, the Jordan Wings x PSG Varsity Jacket blends premium materials with timeless sport style. Featuring a cashmere-blend body, leather shoulder panels in a wing-inspired design, and an allover embroidered ICI C’EST PARIS monogram, it’s finished with a matching satin lining and ribbed cuffs and collar. Available in Blue Void, this jacket delivers a truly standout look.",
                      Brand = "psg",
                      Quantity = 50,
                      Price = 2100.00m,
                      Dimensions = "66x46x6 cm",
                      Weight = "1400",
                      Size = "M, L, XL",
                      Fabric = "cashmere blend with leather panels",
                      Warranty = "24 months",
                      CategoryId = 3, // 'jacket'
                      ProductTypeId = 1 // 'football'
                  },
                  // Accessories
                  new Product
                  {
                      Id = 28,
                      Name = "Manchester United x New Era Bar Stripe Bucket Hat",
                      Description = "Show your United pride with this official bucket hat, inspired by the design gifted at the 22/23 FA Cup final and revived by fans during the 23/24 celebrations. Featuring bar stripes in fan flag colours and an embroidered devil on the visor, it’s a timeless accessory for true supporters. Made from soft cotton twill for all-day comfort.",
                      Brand = "manchesterunited",
                      Quantity = 200,
                      Price = 30.00m,
                      Dimensions = "30x30x15 cm",
                      Weight = "150",
                      Size = "S, M, L",
                      Fabric = "cotton twill",
                      Warranty = "12 months",
                      CategoryId = 4, // 'accessories' (originally ProductTypeId)
                      ProductTypeId = 2 // 'hat' (originally CategoryId)
                  },
                  new Product
                  {
                      Id = 29,
                      Name = "Manchester United Bucket Hat Fred the Red Plush Red",
                      Description = "Perfect for young fans, this Fred the Red plush is a fun matchday companion or a charming addition to any United-themed room. Dressed in a bucket hat and red devil tee, this mascot toy sports a classic fan look—bringing Manchester United style and spirit home. A great gift for supporters of all ages.",
                      Brand = "manchesterunited",
                      Quantity = 150,
                      Price = 25.00m,
                      Dimensions = "20x15x15 cm",
                      Weight = "300",
                      Size = "One Size",
                      Fabric = "plush fabric",
                      Warranty = "12 months",
                      CategoryId = 4, // 'accessories'
                      ProductTypeId = 3 // 'toy'
                  },
                  new Product
                  {
                      Id = 30,
                      Name = "Manchester United Bar Scarf Gift Box Black",
                      Description = "A stylish gift for any Manchester United fan, this official scarf pairs effortlessly with any outfit while adding a subtle nod to the club. Featuring a sleek black design with white and gold stripes, it’s finished with gold embroidered devils to show your allegiance. Packaged in a premium gift box, it’s the perfect present for the Reds in your life.",
                      Brand = "manchesterunited",
                      Quantity = 250,
                      Price = 20.00m,
                      Dimensions = "180x25x5 cm",
                      Weight = "250",
                      Size = "One Size",
                      Fabric = "acrylic blend",
                      Warranty = "12 months",
                      CategoryId = 4, // 'accessories'
                      ProductTypeId = 4 // 'scarf'
                  },
                  new Product
                  {
                      Id = 31,
                      Name = "Manchester United BRXLZ Large Old Trafford Stadium",
                      Description = "Bring Old Trafford to life with this BRXLZ stadium kit, a must-have for any Manchester United fan. Recreate the iconic Sir Alex Ferguson Stand and experience the magic of the Theatre of Dreams piece by piece. Perfect for model builders or newcomers alike, this detailed kit makes a great gift—and a proud display of your United loyalty once complete.",
                      Brand = "manchesterunited",
                      Quantity = 100,
                      Price = 110.00m,
                      Dimensions = "35x30x15 cm",
                      Weight = "1200",
                      Size = "One Size",
                      Fabric = "plastic bricks",
                      Warranty = "12 months",
                      CategoryId = 4, // 'accessories'
                      ProductTypeId = 3 // 'toy'
                  },
                  new Product
                  {
                      Id = 32,
                      Name = "Manchester United Size 5 Illustrated Football White",
                      Description = "Add a distinctive piece to your collection with this official Manchester United illustrated football. Featuring detailed line drawings by Manchester artist Izzy Winter, the design showcases iconic views of Old Trafford, the city, and club legends. A size 5 ball, it’s perfect as a display piece or a thoughtful keepsake for any devoted fan.",
                      Brand = "manchesterunited",
                      Quantity = 180,
                      Price = 100.00m,
                      Dimensions = "22x22x22 cm",
                      Weight = "450",
                      Size = "Size 5",
                      Fabric = "synthetic leather",
                      Warranty = "12 months",
                      CategoryId = 4, // 'accessories'
                      ProductTypeId = 1 // 'football (ball)'
                  },
                  new Product
                  {
                      Id = 33,
                      Name = "Manchester United x New Era Kids 9Forty Core Cap",
                      Description = "The perfect finishing touch for any young fan’s outfit, this classic kids’ baseball cap features the iconic Manchester United crest for a bold show of team pride. Made from breathable cotton twill with a low crown and adjustable D-ring closure, it offers all-day comfort and effortless summer style. A must-have for every junior Red.",
                      Brand = "manchesterunited",
                      Quantity = 220,
                      Price = 26.00m,
                      Dimensions = "28x28x12 cm",
                      Weight = "120",
                      Size = "Kids",
                      Fabric = "cotton twill",
                      Warranty = "12 months",
                      CategoryId = 4, // 'accessories'
                      ProductTypeId = 2 // 'hat'
                  },
                  new Product
                  {
                      Id = 34,
                      Name = "Wayne Rooney, Teenage Kicks Book",
                      Description = "Relive the rise of a football icon in Wayne Rooney: Teenage Kicks. From his early days at Everton to his record-breaking years at Manchester United, this biography explores the key moments of Rooney’s legendary career. Packed with era-defining highlights and behind-the-scenes stories, it’s a must-read for fans eager to learn more about one of football’s greatest talents—a perfect gift for any United supporter.",
                      Brand = "manchesterunited",
                      Quantity = 300,
                      Price = 26.00m,
                      Dimensions = "20x13x3 cm",
                      Weight = "350",
                      Size = "One Size",
                      Fabric = "paper",
                      Warranty = "No warranty",
                      CategoryId = 4, // 'accessories'
                      ProductTypeId = 5 // 'book'
                  },
                  new Product
                  {
                      Id = 35,
                      Name = "Cushioned Crew Socks 3 Pairs",
                      Description = "From daily workouts to game day, these adidas crew-length socks are built for comfort and support. With targeted arch compression and cushioning at the heels and toes, they reduce pressure so you can stay focused on your performance—whether you're training, lifting, or playing.",
                      Brand = "adidas",
                      Quantity = 500,
                      Price = 10.00m,
                      Dimensions = "25x10x5 cm",
                      Weight = "90",
                      Size = "S, M, L",
                      Fabric = "cotton blend",
                      Warranty = "6 months",
                      CategoryId = 4, // 'accessories'
                      ProductTypeId = 6 // 'socks'
                  },
                  new Product
                  {
                      Id = 36,
                      Name = "Classic Badge Of Sport Backpack",
                      Description = "The backpack is back—and better than ever. This adidas classic blends style and function, with space for everything from your laptop to your gym gear. A side pocket keeps your water bottle within easy reach, while its clean design makes it a go-to for daily use.",
                      Brand = "adidas",
                      Quantity = 150,
                      Price = 25.00m,
                      Dimensions = "45x30x15 cm",
                      Weight = "900",
                      Size = "One Size",
                      Fabric = "polyester",
                      Warranty = "12 months",
                      CategoryId = 4, // 'accessories'
                      ProductTypeId = 7 // 'bag'
                  },
                  new Product
                  {
                      Id = 37,
                      Name = "Predator Training Goalkeeper Gloves",
                      Description = "Sharpen your skills with adidas Predator Training goalkeeper gloves. Designed for reliable grip and comfort, they feature a cushioned Soft Grip latex palm, flexible backhand, and a roomy finger cut for confident saves. An adjustable elastic bandage strap ensures a secure, stable fit so you can focus on every shot.",
                      Brand = "adidas",
                      Quantity = 180,
                      Price = 38.00m,
                      Dimensions = "25x15x5 cm",
                      Weight = "300",
                      Size = "S, M, L",
                      Fabric = "latex and polyester",
                      Warranty = "12 months",
                      CategoryId = 4, // 'accessories'
                      ProductTypeId = 8 // 'gloves' (originally CategoryId, re-purposing 8 for gloves as per your comment)
                  },
                  new Product
                  {
                      Id = 38,
                      Name = "Outline Trefoil Shoulder Bag",
                      Description = "Designed to complement your everyday look, this adidas shoulder bag offers sleek, effortless style. Featuring a clean, minimalist design with an embossed Trefoil logo and refined outline stitching, it holds your essentials with ease. The padded shoulder strap ensures all-day comfort wherever you go.",
                      Brand = "adidas",
                      Quantity = 120,
                      Price = 55.00m,
                      Dimensions = "35x20x10 cm",
                      Weight = "600",
                      Size = "One Size",
                      Fabric = "polyester",
                      Warranty = "12 months",
                      CategoryId = 4, // 'accessories'
                      ProductTypeId = 7 // 'bag'
                  }
              );
            modelBuilder.Entity<ProductImage>().HasData(
            // Jerseys (Product IDs 1-13)
            new ProductImage { Id = 1, ImagePath = "product_data/jerseys/manchesterunited/product1", ProductId = 1 },
            new ProductImage { Id = 2, ImagePath = "product_data/jerseys/manchesterunited/product2", ProductId = 2 },
            new ProductImage { Id = 3, ImagePath = "product_data/jerseys/manchesterunited/product3", ProductId = 3 },
            new ProductImage { Id = 4, ImagePath = "product_data/jerseys/realmadrid/product1", ProductId = 4 },
            new ProductImage { Id = 5, ImagePath = "product_data/jerseys/realmadrid/product2", ProductId = 5 },
            new ProductImage { Id = 6, ImagePath = "product_data/jerseys/barcelona/product1", ProductId = 6 },
            new ProductImage { Id = 7, ImagePath = "product_data/jerseys/barcelona/product2", ProductId = 7 },
            new ProductImage { Id = 8, ImagePath = "product_data/jerseys/acmilan/product1", ProductId = 8 },
            new ProductImage { Id = 9, ImagePath = "product_data/jerseys/acmilan/product2", ProductId = 9 },
            new ProductImage { Id = 10, ImagePath = "product_data/jerseys/bayern/product1", ProductId = 10 },
            new ProductImage { Id = 11, ImagePath = "product_data/jerseys/psg/product1", ProductId = 11 },
            new ProductImage { Id = 12, ImagePath = "product_data/jerseys/intermilan/product1", ProductId = 12 },
            new ProductImage { Id = 13, ImagePath = "product_data/jerseys/dortmund/product1", ProductId = 13 },

            // Shoes (Product IDs 14-21)
            new ProductImage { Id = 14, ImagePath = "product_data/shoes/nike/product1", ProductId = 14 },
            new ProductImage { Id = 15, ImagePath = "product_data/shoes/nike/product2", ProductId = 15 },
            new ProductImage { Id = 16, ImagePath = "product_data/shoes/nike/product3", ProductId = 16 },
            new ProductImage { Id = 17, ImagePath = "product_data/shoes/adidas/product1", ProductId = 17 },
            new ProductImage { Id = 18, ImagePath = "product_data/shoes/adidas/product2", ProductId = 18 },
            new ProductImage { Id = 19, ImagePath = "product_data/shoes/adidas/product3", ProductId = 19 },
            new ProductImage { Id = 20, ImagePath = "product_data/shoes/adidas/product4", ProductId = 20 },
            new ProductImage { Id = 21, ImagePath = "product_data/shoes/adidas/product5", ProductId = 21 },

            // Jackets (Product IDs 22-27)
            new ProductImage { Id = 22, ImagePath = "product_data/jackets/machesterunited/product1", ProductId = 22 },
            new ProductImage { Id = 23, ImagePath = "product_data/jackets/machesterunited/product2", ProductId = 23 },
            new ProductImage { Id = 24, ImagePath = "product_data/jackets/acmilan/product1", ProductId = 24 },
            new ProductImage { Id = 25, ImagePath = "product_data/jackets/realmadrid/product1", ProductId = 25 },
            new ProductImage { Id = 26, ImagePath = "product_data/jackets/intermilan/product1", ProductId = 26 },
            new ProductImage { Id = 27, ImagePath = "product_data/jackets/psg/product1", ProductId = 27 },

            // Accessories (Product IDs 28-38) - Using the base path from the Product seed data
            new ProductImage { Id = 28, ImagePath = "product_data/accessories/manchesterunited/product1", ProductId = 28 },
            new ProductImage { Id = 29, ImagePath = "product_data/accessories/manchesterunited/product2", ProductId = 29 },
            new ProductImage { Id = 30, ImagePath = "product_data/accessories/manchesterunited/product3", ProductId = 30 },
            new ProductImage { Id = 31, ImagePath = "product_data/accessories/manchesterunited/product4", ProductId = 31 },
            new ProductImage { Id = 32, ImagePath = "product_data/accessories/manchesterunited/product5", ProductId = 32 },
            new ProductImage { Id = 33, ImagePath = "product_data/accessories/manchesterunited/product6", ProductId = 33 },
            new ProductImage { Id = 34, ImagePath = "product_data/accessories/manchesterunited/product7", ProductId = 34 },
            new ProductImage { Id = 35, ImagePath = "product_data/accessories/adidas/product1", ProductId = 35 },
            new ProductImage { Id = 36, ImagePath = "product_data/accessories/adidas/product2", ProductId = 36 },
            new ProductImage { Id = 37, ImagePath = "product_data/accessories/adidas/product3", ProductId = 37 },
            new ProductImage { Id = 38, ImagePath = "product_data/accessories/adidas/product4", ProductId = 38 }
        );
        }
        
        

    }
}