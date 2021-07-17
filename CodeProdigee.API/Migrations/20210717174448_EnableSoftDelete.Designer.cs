﻿// <auto-generated />
using System;
using System.Collections.Generic;
using CodeProdigee.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CodeProdigee.API.Migrations
{
    [DbContext(typeof(CodeProdigeeContext))]
    [Migration("20210717174448_EnableSoftDelete")]
    partial class EnableSoftDelete
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("CodeProdigee.API.Models.Author", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AuthorEmail")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("AuthorGithub")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("AuthorName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("AuthorTwitter")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("AvatarImage")
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)");

                    b.Property<string>("Bio")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("CodeProdigee.API.Models.Blog", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AdminName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<string>("BlogAdminEmail")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("BlogName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("CodeProdigee.API.Models.Comment", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("AuthorID")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CommentAuthorID")
                        .HasColumnType("uuid");

                    b.Property<string>("CommentBody")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<Guid?>("CommentID")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<List<bool>>("DisLikes")
                        .HasColumnType("boolean[]");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<List<bool>>("Likes")
                        .HasColumnType("boolean[]");

                    b.Property<Guid>("PostID")
                        .HasColumnType("uuid");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("AuthorID");

                    b.HasIndex("CommentAuthorID");

                    b.HasIndex("CommentID");

                    b.HasIndex("PostID");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("CodeProdigee.API.Models.Commentator", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.Property<int>("ViolationCount")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.ToTable("Commentators");
                });

            modelBuilder.Entity("CodeProdigee.API.Models.Post", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AuthorID")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("BlogID")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("PostBody")
                        .IsRequired()
                        .HasMaxLength(3000)
                        .HasColumnType("character varying(3000)");

                    b.Property<DateTimeOffset>("PostDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("PostTitle")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<DateTimeOffset>("PublishDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("PublishPost")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("ID");

                    b.HasIndex("AuthorID");

                    b.HasIndex("BlogID");

                    b.HasIndex("PostTitle")
                        .IsUnique();

                    b.HasIndex("PublishDate");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("CodeProdigee.API.Models.PostResources", b =>
                {
                    b.Property<Guid>("PostID")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ResourceID")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<Guid>("ID")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("PostID1")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("PublishDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("ResourceID1")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.HasKey("PostID", "ResourceID");

                    b.HasIndex("PostID1");

                    b.HasIndex("ResourceID");

                    b.HasIndex("ResourceID1");

                    b.ToTable("PostResources");
                });

            modelBuilder.Entity("CodeProdigee.API.Models.PostTags", b =>
                {
                    b.Property<Guid>("PostID")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TagID")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<Guid>("ID")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("PostID1")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("PublishDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("TagID1")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.HasKey("PostID", "TagID");

                    b.HasIndex("PostID1");

                    b.HasIndex("TagID");

                    b.HasIndex("TagID1");

                    b.ToTable("PostTags");
                });

            modelBuilder.Entity("CodeProdigee.API.Models.Resource", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<int>("PostResourceType")
                        .HasColumnType("integer");

                    b.Property<string>("ResourceUrl")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Resources");
                });

            modelBuilder.Entity("CodeProdigee.API.Models.Tag", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("TagName")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("PostResource", b =>
                {
                    b.Property<Guid>("PostsID")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ResourcesID")
                        .HasColumnType("uuid");

                    b.HasKey("PostsID", "ResourcesID");

                    b.HasIndex("ResourcesID");

                    b.ToTable("PostResource");
                });

            modelBuilder.Entity("PostTag", b =>
                {
                    b.Property<Guid>("PostsID")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TagsID")
                        .HasColumnType("uuid");

                    b.HasKey("PostsID", "TagsID");

                    b.HasIndex("TagsID");

                    b.ToTable("PostTag");
                });

            modelBuilder.Entity("CodeProdigee.API.Models.Comment", b =>
                {
                    b.HasOne("CodeProdigee.API.Models.Author", null)
                        .WithMany("AuthorComments")
                        .HasForeignKey("AuthorID");

                    b.HasOne("CodeProdigee.API.Models.Commentator", "CommentAuthor")
                        .WithMany("CommentatorComments")
                        .HasForeignKey("CommentAuthorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CodeProdigee.API.Models.Comment", null)
                        .WithMany("Replies")
                        .HasForeignKey("CommentID");

                    b.HasOne("CodeProdigee.API.Models.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CommentAuthor");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("CodeProdigee.API.Models.Post", b =>
                {
                    b.HasOne("CodeProdigee.API.Models.Author", "PostAuthor")
                        .WithMany("AuthorPosts")
                        .HasForeignKey("AuthorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CodeProdigee.API.Models.Blog", null)
                        .WithMany("Posts")
                        .HasForeignKey("BlogID");

                    b.Navigation("PostAuthor");
                });

            modelBuilder.Entity("CodeProdigee.API.Models.PostResources", b =>
                {
                    b.HasOne("CodeProdigee.API.Models.Post", null)
                        .WithMany("PostResources")
                        .HasForeignKey("PostID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CodeProdigee.API.Models.Post", "Post")
                        .WithMany()
                        .HasForeignKey("PostID1");

                    b.HasOne("CodeProdigee.API.Models.Resource", null)
                        .WithMany("PostResources")
                        .HasForeignKey("ResourceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CodeProdigee.API.Models.Resource", "Resource")
                        .WithMany()
                        .HasForeignKey("ResourceID1");

                    b.Navigation("Post");

                    b.Navigation("Resource");
                });

            modelBuilder.Entity("CodeProdigee.API.Models.PostTags", b =>
                {
                    b.HasOne("CodeProdigee.API.Models.Post", null)
                        .WithMany("PostTags")
                        .HasForeignKey("PostID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CodeProdigee.API.Models.Post", "Post")
                        .WithMany()
                        .HasForeignKey("PostID1");

                    b.HasOne("CodeProdigee.API.Models.Tag", null)
                        .WithMany("PostTags")
                        .HasForeignKey("TagID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CodeProdigee.API.Models.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagID1");

                    b.Navigation("Post");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("PostResource", b =>
                {
                    b.HasOne("CodeProdigee.API.Models.Post", null)
                        .WithMany()
                        .HasForeignKey("PostsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CodeProdigee.API.Models.Resource", null)
                        .WithMany()
                        .HasForeignKey("ResourcesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PostTag", b =>
                {
                    b.HasOne("CodeProdigee.API.Models.Post", null)
                        .WithMany()
                        .HasForeignKey("PostsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CodeProdigee.API.Models.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CodeProdigee.API.Models.Author", b =>
                {
                    b.Navigation("AuthorComments");

                    b.Navigation("AuthorPosts");
                });

            modelBuilder.Entity("CodeProdigee.API.Models.Blog", b =>
                {
                    b.Navigation("Posts");
                });

            modelBuilder.Entity("CodeProdigee.API.Models.Comment", b =>
                {
                    b.Navigation("Replies");
                });

            modelBuilder.Entity("CodeProdigee.API.Models.Commentator", b =>
                {
                    b.Navigation("CommentatorComments");
                });

            modelBuilder.Entity("CodeProdigee.API.Models.Post", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("PostResources");

                    b.Navigation("PostTags");
                });

            modelBuilder.Entity("CodeProdigee.API.Models.Resource", b =>
                {
                    b.Navigation("PostResources");
                });

            modelBuilder.Entity("CodeProdigee.API.Models.Tag", b =>
                {
                    b.Navigation("PostTags");
                });
#pragma warning restore 612, 618
        }
    }
}
