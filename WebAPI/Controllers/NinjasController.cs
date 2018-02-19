﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Newtonsoft.Json;
using NinjaDomain.Clases;
using NinjaDomain.DataModels;

namespace WebAPI.Controllers
{
    public class NinjasController : ApiController
    {
        private readonly DisconnectedRepository _repo = new DisconnectedRepository();

        public IEnumerable<ViewListNinja> Get(string query = "", int page = 0, int pageSize = 20)
        {
            var ninjas = _repo.GetQueryableNinjasWithClan(query, page, pageSize);
            return ninjas.Select(n => new ViewListNinja
            {
                ClanName = n.Clan.ClanName,
                DateOfBirth = n.DateOfBirth,
                Id = n.Id,
                Name = n.Name,
                ServedInOniwaban = n.ServedInOniwaban
            });
        }

        public Ninja Get(int id)
        {
            return _repo.GetNinjaWithEquipmentAndClan(id);
        }

        public void Post([FromBody] object ninja)
        {
            var asNinja = JsonConvert.DeserializeObject<Ninja>(ninja.ToString());

            _repo.SaveUpdatedNinja(asNinja);
        }

        public void Put(int id, [FromBody] Ninja ninja)
        {
            _repo.SaveNewNinja(ninja);
        }


        public void Delete(int id)
        {
            _repo.DeleteNinja(id);
        }

    }
}