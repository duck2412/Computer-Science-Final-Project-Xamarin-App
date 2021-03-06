﻿using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Prototype.ModelControllers;
using Prototype.Models;

namespace Prototype.ViewModels
{
    public class ArticleViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly StateController _stateController;
        private Article _article;
        public Article Article
        {
            get { return _article; }
            set
            {
                if (_article == value) { return; }
                _article = value;
                Notify("Article");
            }
        }

        private bool _locked;
        public bool Locked
        {
            get { return _locked; }
            set
            {
                if (_locked == value) { return; }
                _locked = value;
                Notify("Locked");
            }
        }

        private bool _subscriberHasAccess;
        public bool SubscriberHasAccess
        {
            get { return _subscriberHasAccess; }
            set
            {
                if (_subscriberHasAccess == value) { return; }
                _subscriberHasAccess = value;
                Notify("SubscriberHasAccess");
            }
        }

        private bool _lockedIndicatorImageVisible;
        public bool LockedIndicatorImageVisible
        {
            get { return _lockedIndicatorImageVisible; }
            set
            {
                if (_lockedIndicatorImageVisible == value) { return; }
                _lockedIndicatorImageVisible = value;
                Notify("LockedIndicatorImageVisible");
            }
        }

        private bool _unlockedIndicatorImageVisible;
        public bool UnlockedIndicatorImageVisible
        {
            get { return _unlockedIndicatorImageVisible; }
            set
            {
                if (_unlockedIndicatorImageVisible == value) { return; }
                _unlockedIndicatorImageVisible = value;
                Notify("UnlockedIndicatorImageVisible");
            }
        }

        public ArticleViewModel(StateController stateController, Article articleToDisplay)
        {
            this._stateController = stateController;

            Article = articleToDisplay;

            Locked = CalculateIfArticleShouldBeLocked();

            SavedArticlesChanged();
        }

        /// <summary>
        /// Checks if the article is saved by the user and sets IsSaved accordingly. 
        /// If IsSaved == true, then an icon indicating this state is shown
        /// </summary>
        public void SavedArticlesChanged()
        {
            if (_stateController.ArticleController.SavedArticles.Contains(Article))
            {
                Article.IsSaved = true;
            }
            else
            {
                Article.IsSaved = false;
            }
        }

        /// <summary>
        /// Calculates wether the view should lock the article based on the logged or not not logged in subscribers access and the locked property on the article.
        /// </summary>
        /// <returns></returns>
        public bool CalculateIfArticleShouldBeLocked()
        {
            if (_stateController.LoginController.Subscriber != null)
            {
                SubscriberHasAccess = _stateController.LoginController.Subscriber.HasAccessToSite();
            }
            else
            {
                SubscriberHasAccess = false;
            }

            var locked = Article.locked;
            if (locked && SubscriberHasAccess)
            {
                //If the subscriber is logged in, has access and the article is also locked, show the unlocked icon
                UnlockedIndicatorImageVisible = true;
                LockedIndicatorImageVisible = false;
                SubscriberHasAccess = true;
            }
            else if (locked)
            {
                //If the article is locked and subscriber is not logged in or does not have access, show the locked icon
                LockedIndicatorImageVisible = true;
                UnlockedIndicatorImageVisible = false;
                SubscriberHasAccess = false;

            }
            else
            {
                //If article is not locked, show no icons
                LockedIndicatorImageVisible = false;
                UnlockedIndicatorImageVisible = false;
                SubscriberHasAccess = true;
            }

            return locked;
        }

        /// <summary>
        /// Downloads the details for the article.
        /// </summary>
        /// <returns></returns>
        public async Task<ArticleViewModel> GetArticleDetails()
        {
            try
            {
                if (Article.bodyText == "")
                {
                    Article = await this._stateController.GetArticleDetails(Article);
                }
            }
            catch (Exception e) { }

            try
            {
                Article.relatedDetailedArticles = await this._stateController.GetRelatedArticles(Article);
            }
            catch (Exception e) { }

            return this;
        }

        protected void Notify(string propName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
