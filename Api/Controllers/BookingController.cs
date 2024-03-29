﻿using LinkDev.EgyptianRecipes.Data.Dtos;
using LinkDev.EgyptianRecipes.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LinkDev.EgyptianRecipes.Controllers;

[ApiController]
[Route("[controller]/[Action]")]
[AllowAnonymous]
public class BookingController : Controller
{
    private readonly IBookingService _service;

    public BookingController(IBookingService service)
    {
        _service = service;
    }


    [HttpPost]
    public async Task<IActionResult> AvailableTimeslotsFromBranches(AvailableBranchesDto availableBranchesDto)
    {
        if (availableBranchesDto.Day.ToLocalTime().Date == DateTime.Today)
        {
            availableBranchesDto.Day = DateTime.Now.AddMinutes(1);
        }
        
        var result = await _service.AvailableTimeslotsFromBranches(availableBranchesDto.Day, availableBranchesDto.BranchId);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> AddBooking(BookingDto bookingDto)
    {
        if (!ModelState.IsValid)
            return Json("model is not valid");

        var result = await _service.AddBookingAsync(bookingDto);

        return Ok(result);
    }
}