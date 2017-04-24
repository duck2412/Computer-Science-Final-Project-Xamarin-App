﻿using Prototype.ModelControllers;
using Prototype.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prototype.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ArticleView : ContentPage
	{
        private StateController StateController;
        private Article Article;
		public ArticleView (StateController stateController, Article article)
		{
			InitializeComponent ();
            this.StateController = stateController;
            this.Article = article;
            BindingContext = Article;

            //stateController.downloadArticleBigImage(article);
        }

    }
}
