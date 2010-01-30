﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alsing.Messaging;
using MyBlog.Domain.Events;

namespace MyBlog.Domain.Entities
{
    public partial class Post 
    {
         public void ReplyTo(string userName,string userEmail,string userWebsite,string text)
        {
            var userInfo = new UserInfo(userName, userEmail, userWebsite);
            var comment = new Comment(this, userInfo, text);
            _comments.Add(comment);

            DomainEvents.Raise(new RepliedToPost(this,comment));
        }

        public void Edit(string subject, string body)
        {
            this.Subject = subject;
            this.Body = body;

            DomainEvents.Raise(new EditedPost(this));
        }

        public void EnableComments()
        {
            this.CommentsEnabled = true;

            DomainEvents.Raise(new EnabledComments(this));
        }

        public void DisableComments()
        {
            this.CommentsEnabled = false;

            DomainEvents.Raise(new DisabledComments(this));
        }

        public void Publish()
        {
            this.PublishDate = DateTime.Now;

            DomainEvents.Raise(new PublishedPost(this));
        }

        public void Unpublish()
        {
            this.PublishDate = null;

            DomainEvents.Raise(new UnpublishedPost(this));
        }

        public void AssignCategory(Category category)
        {
            _categories.Add(category);

            DomainEvents.Raise(new AssignedCategoryToPost(this, category));
        }
    }
}