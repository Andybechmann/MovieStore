﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace MovieStoreDAL.Infrastructure
{
    public class ServiceGateway <TEntity> where TEntity : IEntity
    {

        private readonly string path;
        private readonly string hostUri;

        public ServiceGateway(string path, string hostUri = "http://localhost:7447/")
        { 
            this.hostUri = hostUri;
            this.path = path;
        }

        public IEnumerable<TEntity> GetAll()
        {
            HttpClient client = GetHttpClient();
            HttpResponseMessage response = client.GetAsync(path).Result;
            var entities = response.Content.ReadAsAsync<IEnumerable<TEntity>>().Result;
            return entities;

        }

        public TEntity GetOne(int id)
        {
            HttpClient client = GetHttpClient();
            HttpResponseMessage response = client.GetAsync(path + id.ToString()).Result;
            var entity = response.Content.ReadAsAsync<TEntity>().Result;
            return entity;
        }

        public TEntity GetOne(int id,string properties)
        {
            HttpClient client = GetHttpClient();
            HttpResponseMessage response = client.GetAsync(path + id.ToString() + "?properties=" + properties ).Result;
            var entity = response.Content.ReadAsAsync<TEntity>().Result;
            return entity;
        }

        public HttpResponseMessage CreateOne(TEntity entity)
        {
            HttpClient client = GetHttpClient();
            HttpResponseMessage response = client.PostAsJsonAsync(path, entity).Result;
            return response;
        }

        public HttpResponseMessage Update(TEntity entity)
        {
            HttpClient client = GetHttpClient();
            HttpResponseMessage response = client.PutAsJsonAsync(path + entity.Id.ToString(), entity).Result;
            return response;
        }

        public HttpResponseMessage Delete(int id)
        {
            HttpClient client = GetHttpClient();
            HttpResponseMessage response = client.DeleteAsync(path + id.ToString()).Result;

            return response;
        }

        private HttpClient GetHttpClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(hostUri);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
    }
}
