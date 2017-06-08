﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Core.Issues.Comments.Parameters
{
    public class CommentAddArgs
    {
        /// <summary>
        /// json format
        /// </summary>
        public string Format { get { return Constants.Format.Json; } }

        /// <summary>
        /// the issue key
        /// </summary>
        public string IssueKey { get; set; }

        /// <summary>
        /// the comment text
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// format the data to send to Sonar
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format("issue={0}&text={1}&format={2}", IssueKey, HttpUtility.UrlEncode(Text), Format);
        }
    }
}