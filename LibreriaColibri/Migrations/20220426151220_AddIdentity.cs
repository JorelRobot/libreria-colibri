using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibreriaColibri.Migrations
{
    public partial class AddIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            //migrationBuilder.CreateTable(
            //    name: "t_Authors",
            //    columns: table => new
            //    {
            //        id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        nameAuthor = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_t_Authors", x => x.id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "t_Categories",
            //    columns: table => new
            //    {
            //        id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        nameCat = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_t_Categories", x => x.id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "t_PublishingHouse",
            //    columns: table => new
            //    {
            //        id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        namePH = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_t_PublishingHouse", x => x.id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "t_ShoppingCar",
            //    columns: table => new
            //    {
            //        id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        idUser = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_t_ShoppingCar", x => x.id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "t_Status",
            //    columns: table => new
            //    {
            //        id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        statusName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_t_Status", x => x.id);
            //    });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            //migrationBuilder.CreateTable(
            //    name: "t_Books",
            //    columns: table => new
            //    {
            //        id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        tittle = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
            //        idPH = table.Column<int>(type: "int", nullable: false),
            //        price = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
            //        stock = table.Column<int>(type: "int", nullable: false),
            //        depot = table.Column<int>(type: "int", nullable: false),
            //        img = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
            //        sold = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_t_Books", x => x.id);
            //        table.ForeignKey(
            //            name: "FK_t_PublishingHouse_t_Books",
            //            column: x => x.idPH,
            //            principalTable: "t_PublishingHouse",
            //            principalColumn: "id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "t_Orders",
            //    columns: table => new
            //    {
            //        id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        date = table.Column<DateTime>(type: "datetime", nullable: false),
            //        idStatus = table.Column<int>(type: "int", nullable: false),
            //        idUser = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_t_Orders", x => x.id);
            //        table.ForeignKey(
            //            name: "FK_t_Orders_t_Status",
            //            column: x => x.idStatus,
            //            principalTable: "t_Status",
            //            principalColumn: "id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "t_BookAuthor",
            //    columns: table => new
            //    {
            //        idBook = table.Column<int>(type: "int", nullable: false),
            //        idAuthor = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.ForeignKey(
            //            name: "FK__t_BookAut__idAut__5535A963",
            //            column: x => x.idAuthor,
            //            principalTable: "t_Authors",
            //            principalColumn: "id");
            //        table.ForeignKey(
            //            name: "FK__t_BookAut__idBoo__5441852A",
            //            column: x => x.idBook,
            //            principalTable: "t_Books",
            //            principalColumn: "id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "t_BookCategory",
            //    columns: table => new
            //    {
            //        idBook = table.Column<int>(type: "int", nullable: false),
            //        idCategory = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.ForeignKey(
            //            name: "FK__t_BookCat__idBoo__6EF57B66",
            //            column: x => x.idBook,
            //            principalTable: "t_Books",
            //            principalColumn: "id");
            //        table.ForeignKey(
            //            name: "FK__t_BookCat__idCat__6FE99F9F",
            //            column: x => x.idCategory,
            //            principalTable: "t_Categories",
            //            principalColumn: "id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "t_CarBook",
            //    columns: table => new
            //    {
            //        idCar = table.Column<int>(type: "int", nullable: true),
            //        idBook = table.Column<int>(type: "int", nullable: true),
            //        quantity = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.ForeignKey(
            //            name: "FK__t_CarBook__idBoo__6D0D32F4",
            //            column: x => x.idBook,
            //            principalTable: "t_Books",
            //            principalColumn: "id");
            //        table.ForeignKey(
            //            name: "FK__t_CarBook__idCar__0C85DE4D",
            //            column: x => x.idCar,
            //            principalTable: "t_ShoppingCar",
            //            principalColumn: "id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "t_OrderBook",
            //    columns: table => new
            //    {
            //        idOrder = table.Column<int>(type: "int", nullable: false),
            //        idBook = table.Column<int>(type: "int", nullable: false),
            //        quantity = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.ForeignKey(
            //            name: "FK__t_OrderBo__idBoo__628FA481",
            //            column: x => x.idBook,
            //            principalTable: "t_Books",
            //            principalColumn: "id");
            //        table.ForeignKey(
            //            name: "FK__t_OrderBo__idOrd__6383C8BA",
            //            column: x => x.idOrder,
            //            principalTable: "t_Orders",
            //            principalColumn: "id");
            //    });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            //migrationBuilder.CreateIndex(
            //    name: "IX_t_BookAuthor_idAuthor",
            //    table: "t_BookAuthor",
            //    column: "idAuthor");

            //migrationBuilder.CreateIndex(
            //    name: "IX_t_BookAuthor_idBook",
            //    table: "t_BookAuthor",
            //    column: "idBook");

            //migrationBuilder.CreateIndex(
            //    name: "IX_t_BookCategory_idBook",
            //    table: "t_BookCategory",
            //    column: "idBook");

            //migrationBuilder.CreateIndex(
            //    name: "IX_t_BookCategory_idCategory",
            //    table: "t_BookCategory",
            //    column: "idCategory");

            //migrationBuilder.CreateIndex(
            //    name: "IX_t_Books_idPH",
            //    table: "t_Books",
            //    column: "idPH");

            //migrationBuilder.CreateIndex(
            //    name: "IX_t_CarBook_idBook",
            //    table: "t_CarBook",
            //    column: "idBook");

            //migrationBuilder.CreateIndex(
            //    name: "IX_t_CarBook_idCar",
            //    table: "t_CarBook",
            //    column: "idCar");

            //migrationBuilder.CreateIndex(
            //    name: "IX_t_OrderBook_idBook",
            //    table: "t_OrderBook",
            //    column: "idBook");

            //migrationBuilder.CreateIndex(
            //    name: "IX_t_OrderBook_idOrder",
            //    table: "t_OrderBook",
            //    column: "idOrder");

            //migrationBuilder.CreateIndex(
            //    name: "IX_t_Orders_idStatus",
            //    table: "t_Orders",
            //    column: "idStatus");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            //migrationBuilder.DropTable(
            //    name: "t_BookAuthor");

            //migrationBuilder.DropTable(
            //    name: "t_BookCategory");

            //migrationBuilder.DropTable(
            //    name: "t_CarBook");

            //migrationBuilder.DropTable(
            //    name: "t_OrderBook");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            //migrationBuilder.DropTable(
            //    name: "t_Authors");

            //migrationBuilder.DropTable(
            //    name: "t_Categories");

            //migrationBuilder.DropTable(
            //    name: "t_ShoppingCar");

            //migrationBuilder.DropTable(
            //    name: "t_Books");

            //migrationBuilder.DropTable(
            //    name: "t_Orders");

            //migrationBuilder.DropTable(
            //    name: "t_PublishingHouse");

            //migrationBuilder.DropTable(
            //    name: "t_Status");
        }
    }
}
