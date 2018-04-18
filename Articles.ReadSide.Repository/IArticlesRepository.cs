﻿using Articles.ReadSide.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Articles.ReadSide.Repository
{
	public interface IArticlesRepository
	{
		void ApproveArticle(Guid categoryId, Guid articleId);
		void DeleteArticle(string categoryId, string articleId);
		void DeleteCategory(Guid categoryId);
		void DeleteComment(string categoryId, string commentId);
		string GetArticleBody(string categoryId, string articleId);
		//ArticleProvider GetArticleById(Guid articleId);
		int GetArticleCount();
		int GetArticleCount(Guid categoryId);
		//IList<ArticleProvider> GetArticles(int pageIndex, int pageSize);
		//IList<ArticleProvider> GetArticles(Guid categoryId, int pageIndex, int pageSize);
		//IList<Category> GetCategories();
		//IList<Category> GetCategories(int pageSize, int pageIndex);
		//Category GetCategoryById(Guid categoryId);
		//CommentProvider GetCommentById(Guid commentId);
		int GetCommentCount(Guid articleId);
		int GetCommentCount();
		//IList<CommentProvider> GetComments(int pageIndex, int pageSize);
		//IList<CommentProvider> GetComments(Guid articleId, int pageIndex, int pageSize);
		int GetPublishedArticleCount(DateTime currentDate);
		int GetPublishedArticleCount(Guid categoryId, DateTime currentDate);
		//IList<ArticleProvider> GetPublishedArticles(Guid categoryId, DateTime currentDate, int pageIndex, int pageSize);
		//IList<ArticleProvider> GetPublishedArticles(DateTime currentDate, int pageIndex, int pageSize);
		void IncrementArticleViewCount(Guid articleId);
		void InsertArticle(Article article);
		void InsertCategory(Category category);
		void InsertComment(string categoryId, string artecleId, Comment comment);
		void RateArticle(Guid articleId, int rating);
		//void UpdateArticle(Article article);
		//void UpdateCategory(Category category);
		//void UpdateComment(Comment article);
	}
}
