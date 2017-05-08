﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Prototype.Models
{
    /// <summary>
    /// JSON Generated class
    /// </summary>
    public class Article : IEquatable<Article>
    {

        //Generated fields start
        public Image image { get; set; }
        public string desktopUrl { get; set; }
        public string homeSectionName { get; set; }
        public string contentUrl { get; set; }
        public Titles titles { get; set; }
        public Teasers teasers { get; set; }
        public int homeSectionId { get; set; }
        public string publishedDate { get; set; }
        public DateTime publishedDateTime { get; set; }
        public bool locked { get; set; }
        public bool isTopArticle { get; set; }
        public List<object> inlineImages { get; set; }
        public Metadata metadata { get; set; }
        public bool breakingNews { get; set; }
        public object partner { get; set; }
        public string bodyText { get; set; }
        public string c_name { get; set; }
        public string c_category { get; set; }
        public List<object> tags { get; set; }
        public List<RelatedArticle> relatedArticles { get; set; }
        public List<TopImage> topImages { get; set; }
        public object video { get; set; }
        public List<object> quoteBoxes { get; set; }
        public List<object> reviewBoxes { get; set; }
        public List<object> factsBoxes { get; set; }
        public object updateInfo { get; set; }
        public PublishData publishData { get; set; }
        public string lastModified { get; set; }
        public int id { get; set; }
        //Generated fields end


        //Manually made fields start
        public IList<Article> relatedDetailedArticles { get; set; }
        //Used because we want to acces the first topImage in the topImages list. 
        public TopImage topImage { get; set; }
        public ImageSource ImagePlaceholderBig { get; set; }
        public ImageSource ImagePlaceholderSmall { get; set; }
        public ImageSource ImageTransparentSmall { get; set; }
        //Manually made fields end

        public Article()
        {
            ImagePlaceholderBig = ImageSource.FromFile("imagePlaceholderBig.png");
            ImagePlaceholderSmall = ImageSource.FromFile("imagePlaceholderSmall.png");
            ImageTransparentSmall = ImageSource.FromFile("imageTransparentSmall.png");
        }

        //Implementation of IEquatable<Article> so we can call contains on a Collection<Article>. This is to avoid dublicates in eg. savedArticles in the statecontroller.
        public bool Equals(Article other)
        {
            return null != other && contentUrl == other.contentUrl;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Article);
        }

        //-----------------> we should override public override int gethashcode() also!!

        public void AddFieldsFromAnotherArticle(Article article)
        {
            //image = article.image;
            //desktopUrl = article.desktopUrl;
            //homeSectionName = article.homeSectionName;
            //contentUrl = article.contentUrl;
            //titles = article.titles;
            //teasers = article.teasers;
            //homeSectionId = article.homeSectionId;
            //publishedDate = article.publishedDate;
            //locked = article.locked;
            //isTopArticle = article.isTopArticle;
            inlineImages = article.inlineImages;
            metadata = article.metadata;
            breakingNews = article.breakingNews;
            partner = article.partner;
            bodyText = article.bodyText;
            c_name = article.c_name;
            c_category = article.c_category;
            tags = article.tags;
            relatedArticles = article.relatedArticles;
            topImages = article.topImages;
            video = article.video;
            quoteBoxes = article.quoteBoxes;
            reviewBoxes = article.reviewBoxes;
            updateInfo = article.updateInfo;
            publishData = article.publishData;
            lastModified = article.lastModified;
            id = article.id;
        }
    }


    /// <summary>
    /// JSON Generated class that is used in Article
    /// </summary>
    public class Titles
    {
        public string DEFAULT { get; set; }
        public object KICKER { get; set; }
        public string FRONTPAGE { get; set; }
    }

    /// <summary>
    /// JSON Generated class that is used in Article
    /// </summary>
    public class Teasers
    {
        public string DEFAULT { get; set; }
        public string FRONTPAGE { get; set; }
    }

    /// <summary>
    /// JSON Generated class that is used in Article
    /// </summary>
    public class Metadata
    {
        public string sectionDisplayName { get; set; }
        public string c_name { get; set; }
        public string c_category { get; set; }
        public string color { get; set; }
    }

    /// <summary>
    /// JSON Generated class that is used in Article
    /// </summary>
    public class Teaser
    {
        public string DEFAULT { get; set; }
        public string FRONTPAGE { get; set; }
    }

    /// <summary>
    /// JSON Generated class that is used in Article
    /// </summary>
    public class RelatedArticle
    {
        public string url { get; set; }
        public string title { get; set; }
        public string sectionName { get; set; }
        public string publishedTime { get; set; }
        public Teaser teaser { get; set; }
        public bool locked { get; set; }
    }

    /// <summary>
    /// JSON Generated class that is used in Article
    /// </summary>
    public class PublishData
    {
        public List<object> authors { get; set; }
        public string publishInfo { get; set; }
        public string publishedTime { get; set; }
        public string publishedTimeFormatted { get; set; }

    }
}
