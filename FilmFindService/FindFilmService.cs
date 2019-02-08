﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FilmFindService.NetwokLayer;

namespace FilmFindService
{ 
    public class FindFilmService
    {
        private Net net = new Net();
        private string BaseUri { get; set; }

        public FindFilmService(string baseUri)
        {
            this.BaseUri = baseUri;
        }

        public async Task<FilmInfo> GetFilms(string filmName)
        {
            if(filmName == null)
            {
                throw new ArgumentNullException();
            }

            filmName = string.Join("+", filmName.Split(' '));

            StringBuilder builder = new StringBuilder();
            builder.Append(BaseUri);
            builder.Append("?t=");
            builder.Append(filmName);
            builder.Append("&plot=full");
            builder.Append("&apikey=b5a32870");

            string jsonResult = await net.GetJson(builder.ToString());
            var filmInfo = JsonConvert.DeserializeObject<FilmInfo>(jsonResult);

            return filmInfo;
        }       
    }
}