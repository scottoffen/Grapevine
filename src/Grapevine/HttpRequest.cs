﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Text;

namespace Grapevine
{
    public class HttpRequest : IHttpRequest
    {
        public HttpListenerRequest Advanced { get; }

        public string[] AcceptTypes => Advanced.AcceptTypes;

        public Encoding ContentEncoding => Advanced.ContentEncoding;

        public long ContentLength64 => Advanced.ContentLength64;

        public string ContentType => Advanced.ContentType;

        public System.Net.CookieCollection Cookies => Advanced.Cookies;

        public bool HasEntityBody => Advanced.HasEntityBody;

        public NameValueCollection Headers => Advanced.Headers;

        public string HostPrefix { get; }

        public HttpMethod HttpMethod => Advanced.HttpMethod;

        public Stream InputStream => Advanced.InputStream;

        public string MultipartBoundary { get; }

        public string Name => $"{HttpMethod} {Endpoint}";

        public string Endpoint { get; protected set; }

        public IDictionary<string, string> PathParameters { get; set; } = new Dictionary<string, string>();

        public NameValueCollection QueryString => Advanced.QueryString;

        public string RawUrl => Advanced.RawUrl;

        public System.Net.IPEndPoint RemoteEndPoint => Advanced.RemoteEndPoint;

        public Uri Url => Advanced.Url;

        public Uri UrlReferrer => Advanced.UrlReferrer;

        public string UserAgent => Advanced.UserAgent;

        public string UserHostAddress => Advanced.UserHostAddress;

        public string UserHostname => Advanced.UserHostName;

        public string[] UserLanguages => Advanced.UserLanguages;

        public HttpRequest(HttpListenerRequest request)
        {
            Advanced = request;
            Endpoint = request.Url.AbsolutePath.TrimEnd('/');
            HostPrefix = request.Url.GetComponents(UriComponents.SchemeAndServer, UriFormat.Unescaped);
            MultipartBoundary = this.GetMultipartBoundary();
        }
    }
}
