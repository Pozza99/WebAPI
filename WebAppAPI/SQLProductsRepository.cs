﻿using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using WebAppAPI.Models;

namespace WebAppAPI
{
    public class SQLProductsRepository : IProductsRepository
    {

        private readonly IConfiguration _configuration;  //installa il nuget più lungo su IConfiguration poi creo il costruttore sottolineando tutto
        private readonly string _connectionString; 

        public SQLProductsRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("Default");
            
        }


        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> Get() //install dapper nuget e un altro che non ricordo
        {
            using(var connection = new SqlConnection(_connectionString)) //crea connessione al Db
            {
                //Query di tipo Product
                return connection.Query<Product>(@"
                    SELECT [Id]
                      ,[Code]
                      ,[Name]
                      ,[Description]
                      ,[Price]
                    FROM [dbo].[Products]");
            }
        }

        public Product GetById(int id)
        {
            using (var connection = new SqlConnection(_connectionString)) //crea connessione al Db
            {
                //Query di tipo Product
                return connection.QueryFirstOrDefault<Product>(@"
                    SELECT [Id]
                      ,[Code]
                      ,[Name]
                      ,[Description]
                      ,[Price]
                    FROM [dbo].[Products]
                    WHERE Id = @ProductId", new { ProductId = id });
            }
        }

        public void Insert(Product product)
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
