using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CSE443_KTM_Ecommerce.Migrations
{
    /// <inheritdoc />
    public partial class ProductImageSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 46, 9, 43, DateTimeKind.Local).AddTicks(8908));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 46, 9, 43, DateTimeKind.Local).AddTicks(8919));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 46, 9, 43, DateTimeKind.Local).AddTicks(8920));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 46, 9, 43, DateTimeKind.Local).AddTicks(8921));

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "DisplayOrder", "ImagePath", "ProductId" },
                values: new object[,]
                {
                    { 1, 0, "product_data/jerseys/manchesterunited/product1", 1 },
                    { 2, 0, "product_data/jerseys/manchesterunited/product2", 2 },
                    { 3, 0, "product_data/jerseys/manchesterunited/product3", 3 },
                    { 4, 0, "product_data/jerseys/realmadrid/product1", 4 },
                    { 5, 0, "product_data/jerseys/realmadrid/product2", 5 },
                    { 6, 0, "product_data/jerseys/barcelona/product1", 6 },
                    { 7, 0, "product_data/jerseys/barcelona/product2", 7 },
                    { 8, 0, "product_data/jerseys/acmilan/product1", 8 },
                    { 9, 0, "product_data/jerseys/acmilan/product2", 9 },
                    { 10, 0, "product_data/jerseys/bayern/product1", 10 },
                    { 11, 0, "product_data/jerseys/psg/product1", 11 },
                    { 12, 0, "product_data/jerseys/intermilan/product1", 12 },
                    { 13, 0, "product_data/jerseys/dortmund/product1", 13 },
                    { 14, 0, "product_data/shoes/nike/product1", 14 },
                    { 15, 0, "product_data/shoes/nike/product2", 15 },
                    { 16, 0, "product_data/shoes/nike/product3", 16 },
                    { 17, 0, "product_data/shoes/adidas/product1", 17 },
                    { 18, 0, "product_data/shoes/adidas/product2", 18 },
                    { 19, 0, "product_data/shoes/adidas/product3", 19 },
                    { 20, 0, "product_data/shoes/adidas/product4", 20 },
                    { 21, 0, "product_data/shoes/adidas/product5", 21 },
                    { 22, 0, "product_data/jackets/machesterunited/product1", 22 },
                    { 23, 0, "product_data/jackets/machesterunited/product2", 23 },
                    { 24, 0, "product_data/jackets/acmilan/product1", 24 },
                    { 25, 0, "product_data/jackets/realmadrid/product1", 25 },
                    { 26, 0, "product_data/jackets/intermilan/product1", 26 },
                    { 27, 0, "product_data/jackets/psg/product1", 27 },
                    { 28, 0, "product_data/accessories/manchesterunited/product1", 28 },
                    { 29, 0, "product_data/accessories/manchesterunited/product2", 29 },
                    { 30, 0, "product_data/accessories/manchesterunited/product3", 30 },
                    { 31, 0, "product_data/accessories/manchesterunited/product4", 31 },
                    { 32, 0, "product_data/accessories/manchesterunited/product5", 32 },
                    { 33, 0, "product_data/accessories/manchesterunited/product6", 33 },
                    { 34, 0, "product_data/accessories/manchesterunited/product7", 34 },
                    { 35, 0, "product_data/accessories/adidas/product1", 35 },
                    { 36, 0, "product_data/accessories/adidas/product2", 36 },
                    { 37, 0, "product_data/accessories/adidas/product3", 37 },
                    { 38, 0, "product_data/accessories/adidas/product4", 38 }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 46, 9, 43, DateTimeKind.Local).AddTicks(8935));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 46, 9, 43, DateTimeKind.Local).AddTicks(8944));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 46, 9, 43, DateTimeKind.Local).AddTicks(8946));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 46, 9, 43, DateTimeKind.Local).AddTicks(8948));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 46, 9, 43, DateTimeKind.Local).AddTicks(8950));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 46, 9, 43, DateTimeKind.Local).AddTicks(8952));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 46, 9, 43, DateTimeKind.Local).AddTicks(8955));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 46, 9, 43, DateTimeKind.Local).AddTicks(8957));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 46, 9, 43, DateTimeKind.Local).AddTicks(8958));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 46, 9, 43, DateTimeKind.Local).AddTicks(8987));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 46, 9, 43, DateTimeKind.Local).AddTicks(8988));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 46, 9, 43, DateTimeKind.Local).AddTicks(8990));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 46, 9, 43, DateTimeKind.Local).AddTicks(8992));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 46, 9, 43, DateTimeKind.Local).AddTicks(8994));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 46, 9, 43, DateTimeKind.Local).AddTicks(8995));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 46, 9, 43, DateTimeKind.Local).AddTicks(8998));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 46, 9, 43, DateTimeKind.Local).AddTicks(9000));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 46, 9, 43, DateTimeKind.Local).AddTicks(9001));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 46, 9, 43, DateTimeKind.Local).AddTicks(9003));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 46, 9, 43, DateTimeKind.Local).AddTicks(9005));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 46, 9, 43, DateTimeKind.Local).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 46, 9, 43, DateTimeKind.Local).AddTicks(9008));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 46, 9, 43, DateTimeKind.Local).AddTicks(9010));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 46, 9, 43, DateTimeKind.Local).AddTicks(9014));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 46, 9, 43, DateTimeKind.Local).AddTicks(9015));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 46, 9, 43, DateTimeKind.Local).AddTicks(9017));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 46, 9, 43, DateTimeKind.Local).AddTicks(9018));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 46, 9, 43, DateTimeKind.Local).AddTicks(9020));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 46, 9, 43, DateTimeKind.Local).AddTicks(9022));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 46, 9, 43, DateTimeKind.Local).AddTicks(9023));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 46, 9, 43, DateTimeKind.Local).AddTicks(9025));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 46, 9, 43, DateTimeKind.Local).AddTicks(9027));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 46, 9, 43, DateTimeKind.Local).AddTicks(9029));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 46, 9, 43, DateTimeKind.Local).AddTicks(9031));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 46, 9, 43, DateTimeKind.Local).AddTicks(9033));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 46, 9, 43, DateTimeKind.Local).AddTicks(9034));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 46, 9, 43, DateTimeKind.Local).AddTicks(9036));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 46, 9, 43, DateTimeKind.Local).AddTicks(9037));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 39, 2, 356, DateTimeKind.Local).AddTicks(5524));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 39, 2, 356, DateTimeKind.Local).AddTicks(5540));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 39, 2, 356, DateTimeKind.Local).AddTicks(5540));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 39, 2, 356, DateTimeKind.Local).AddTicks(5541));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 39, 2, 356, DateTimeKind.Local).AddTicks(5559));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 39, 2, 356, DateTimeKind.Local).AddTicks(5572));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 39, 2, 356, DateTimeKind.Local).AddTicks(5611));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 39, 2, 356, DateTimeKind.Local).AddTicks(5613));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 39, 2, 356, DateTimeKind.Local).AddTicks(5615));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 39, 2, 356, DateTimeKind.Local).AddTicks(5617));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 39, 2, 356, DateTimeKind.Local).AddTicks(5620));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 39, 2, 356, DateTimeKind.Local).AddTicks(5622));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 39, 2, 356, DateTimeKind.Local).AddTicks(5623));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 39, 2, 356, DateTimeKind.Local).AddTicks(5625));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 39, 2, 356, DateTimeKind.Local).AddTicks(5627));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 39, 2, 356, DateTimeKind.Local).AddTicks(5628));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 39, 2, 356, DateTimeKind.Local).AddTicks(5630));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 39, 2, 356, DateTimeKind.Local).AddTicks(5632));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 39, 2, 356, DateTimeKind.Local).AddTicks(5633));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 39, 2, 356, DateTimeKind.Local).AddTicks(5637));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 39, 2, 356, DateTimeKind.Local).AddTicks(5639));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 39, 2, 356, DateTimeKind.Local).AddTicks(5640));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 39, 2, 356, DateTimeKind.Local).AddTicks(5642));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 39, 2, 356, DateTimeKind.Local).AddTicks(5643));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 39, 2, 356, DateTimeKind.Local).AddTicks(5645));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 39, 2, 356, DateTimeKind.Local).AddTicks(5647));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 39, 2, 356, DateTimeKind.Local).AddTicks(5648));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 39, 2, 356, DateTimeKind.Local).AddTicks(5651));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 39, 2, 356, DateTimeKind.Local).AddTicks(5653));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 39, 2, 356, DateTimeKind.Local).AddTicks(5655));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 39, 2, 356, DateTimeKind.Local).AddTicks(5656));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 39, 2, 356, DateTimeKind.Local).AddTicks(5658));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 39, 2, 356, DateTimeKind.Local).AddTicks(5659));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 39, 2, 356, DateTimeKind.Local).AddTicks(5661));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 39, 2, 356, DateTimeKind.Local).AddTicks(5663));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 39, 2, 356, DateTimeKind.Local).AddTicks(5664));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 39, 2, 356, DateTimeKind.Local).AddTicks(5666));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 39, 2, 356, DateTimeKind.Local).AddTicks(5667));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 39, 2, 356, DateTimeKind.Local).AddTicks(5703));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 39, 2, 356, DateTimeKind.Local).AddTicks(5705));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 39, 2, 356, DateTimeKind.Local).AddTicks(5707));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 9, 21, 39, 2, 356, DateTimeKind.Local).AddTicks(5709));
        }
    }
}
