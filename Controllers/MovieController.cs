﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieDbApi.Models;
using Newtonsoft.Json;

namespace MovieDbApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        // GET: MovieController
        [HttpGet]
        public async Task<MovieModel> Get()

        {

            MovieModel movieList = new MovieModel();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://api.themoviedb.org/3/movie/now_playing?api_key=70a5ea8365bc45ccf8dfe966229c0083"))
                {

                    try
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(apiResponse);

                        movieList = (MovieModel)JsonConvert.DeserializeObject<MovieModel>(apiResponse);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }

            return movieList;
        }


        //public ActionResult Index()
        //{
        //    return View();
        //}

        //// GET: MovieController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: MovieController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: MovieController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: MovieController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: MovieController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: MovieController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: MovieController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
