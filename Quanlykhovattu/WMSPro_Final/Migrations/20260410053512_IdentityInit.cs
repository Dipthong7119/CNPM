using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WMSPro.Migrations
{
    /// <inheritdoc />
    public partial class IdentityInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    HoTen = table.Column<string>(type: "TEXT", nullable: false),
                    TrangThai = table.Column<string>(type: "TEXT", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Khos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MaKho = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    TenKho = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    DiaDiem = table.Column<string>(type: "TEXT", maxLength: 300, nullable: false),
                    NguoiPhuTrach = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    GhiChu = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NhaCungCaps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MaNhaCungCap = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    TenNhaCungCap = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    DiaChi = table.Column<string>(type: "TEXT", maxLength: 300, nullable: false),
                    SoDienThoai = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhaCungCaps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhieuNhapKhos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SoPhieu = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    NgayChungTu = table.Column<DateTime>(type: "TEXT", nullable: false),
                    MaHang = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    TenHang = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    MaLo = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    SlThucTe = table.Column<int>(type: "INTEGER", nullable: false),
                    DonGia = table.Column<long>(type: "INTEGER", nullable: false),
                    NhaCungCap = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    MaNhaCungCap = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    TrangThai = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    GhiChu = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    MaViTriGoiY = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    NguoiTaoId = table.Column<string>(type: "TEXT", maxLength: 450, nullable: true),
                    NguoiTaoHoTen = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuNhapKhos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhieuXuatKhos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SoPhieu = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    Ngay = table.Column<DateTime>(type: "TEXT", nullable: false),
                    MaHang = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    TenHang = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    MaLo = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    SlXuat = table.Column<int>(type: "INTEGER", nullable: false),
                    TonSauXuat = table.Column<int>(type: "INTEGER", nullable: false),
                    DoiTac = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    BoPhanNhan = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    LyDoXuat = table.Column<string>(type: "TEXT", maxLength: 300, nullable: false),
                    TrangThai = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    GhiChu = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    NguoiTaoId = table.Column<string>(type: "TEXT", maxLength: 450, nullable: true),
                    NguoiTaoHoTen = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuXuatKhos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VatTus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MaVatTu = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    TenVatTu = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    DonViTinh = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    LoaiVatTu = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    SoLuongTon = table.Column<int>(type: "INTEGER", nullable: false),
                    MucTonToiThieu = table.Column<int>(type: "INTEGER", nullable: false),
                    MaNhaCungCap = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    TenNhaCungCap = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    MaKho = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    MaViTri = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    MaLo = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    SoSeri = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VatTus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ViTris",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MaViTri = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Loai = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    SucChua = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    TinhTrang = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    MatHang = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    MaKho = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViTris", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
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
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
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
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
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
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

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
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Khos_MaKho",
                table: "Khos",
                column: "MaKho",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NhaCungCaps_MaNhaCungCap",
                table: "NhaCungCaps",
                column: "MaNhaCungCap",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhieuNhapKhos_SoPhieu",
                table: "PhieuNhapKhos",
                column: "SoPhieu",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhieuXuatKhos_SoPhieu",
                table: "PhieuXuatKhos",
                column: "SoPhieu",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VatTus_MaVatTu",
                table: "VatTus",
                column: "MaVatTu",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ViTris_MaViTri",
                table: "ViTris",
                column: "MaViTri",
                unique: true);
        }

        /// <inheritdoc />
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

            migrationBuilder.DropTable(
                name: "Khos");

            migrationBuilder.DropTable(
                name: "NhaCungCaps");

            migrationBuilder.DropTable(
                name: "PhieuNhapKhos");

            migrationBuilder.DropTable(
                name: "PhieuXuatKhos");

            migrationBuilder.DropTable(
                name: "VatTus");

            migrationBuilder.DropTable(
                name: "ViTris");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
