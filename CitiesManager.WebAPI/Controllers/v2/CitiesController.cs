﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CitiesManager.Infrastructure.DatabaseContext;
using CitiesManager.Core.Models;
using Microsoft.AspNetCore.Authorization;

namespace CitiesManager.WebAPI.Controllers.v2
{
    /// <summary>
    /// 
    /// </summary>

 [ApiVersion("2.0")]
 public class CitiesController : CustomControllerBase
 {
  private readonly ApplicationDbContext _context;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
  public CitiesController(ApplicationDbContext context)
  {
   _context = context;
  }

  // GET: api/Cities
  /// <summary>
  /// To get list of cities (only city name) from 'cities' table
  /// </summary>
  /// <returns></returns>
  [HttpGet]
  public async Task<ActionResult<IEnumerable<string?>>> GetCities()
  {
   var cities = await _context.Cities
    .OrderBy(temp => temp.CityName)
    .Select(temp => temp.CityName)
    .ToListAsync();
   return cities;
  }
 }
}
