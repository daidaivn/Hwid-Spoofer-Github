﻿using ApiProject.IServices;
using ApiProject.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiProject.Services
{
    public class GenderService : IGenderServices
    {
        private readonly TestTek4TvContext _context;

        public GenderService(TestTek4TvContext context)
        {
            _context = context;
        }

        public dynamic GetCurrentPage(int page)
        {
            var pageRes = 2f;
            var genders = _context.Genders.Skip((page - 1) * (int)pageRes).Take((int)pageRes).ToList();
            var pageCount = Math.Ceiling(_context.Genders.Count() / pageRes);
            var output = genders.Select(c => new
            {
                c.GenderId,
                c.GenderName,
                c.Status,
                pageCount,
            });
            return output;
        }
        public IQueryable<dynamic> getAllGender()
        {
            var output = _context.Genders.Select(c => new
            {
                c.GenderId,
                c.GenderName,
                c.Status,
            });
            return output;
        }
        public dynamic CreateGender(Gender gender)
        {
            if (gender.GenderName.Trim().Equals(""))
            {
                return false;
            }
            Gender rl = new Gender
            {
                GenderName = gender.GenderName.Trim(),
                Status = true,
            };
            _context.Genders.Add(rl);
            _context.SaveChanges();
            return rl;
        }
        public dynamic UpdateGender(Gender gender)
        {
            var checkId = _context.Genders.FirstOrDefault(c => c.GenderId == gender.GenderId);
            if (checkId == null || gender.GenderName.Trim().Equals(""))
            {
                return false;
            }
            checkId.GenderName = gender.GenderName.Trim();
            _context.Genders.Update(checkId);
            _context.SaveChanges();
            return checkId;
        }

        public dynamic ChangeStatus (Gender gender)
        {
            var checkId = _context.Genders.FirstOrDefault(c => c.GenderId == gender.GenderId);
            if (checkId == null)
            {
                return false;
            }
            checkId.Status =! checkId.Status;
            _context.Genders.Update(checkId);
            _context.SaveChanges();
            return checkId;
        }

        public IQueryable<dynamic> SearchByGenderName(Gender gender)
        {
            var keyword = _context.Genders.Where(c => c.GenderName.Contains(gender.GenderName));
            return keyword.ToList().AsQueryable();
        }
        public dynamic SearchGenderById(Gender gender)
        {
            var genderById = _context.Genders.FirstOrDefault(c => c.GenderId == gender.GenderId);
            return genderById;
        }
    }
}
