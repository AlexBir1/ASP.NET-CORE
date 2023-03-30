using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBSHOP.DAL.Repositories.Interfaces;
using WEBSHOP.Domain.Entities;
using WEBSHOP.Domain.ViewModels;

namespace WEBSHOP.DAL.Repositories.Implementations
{
    public class PaymentMethodRepository : IPaymentMethodInterface
    {
        private readonly AppDBContext _db;

        public PaymentMethodRepository(AppDBContext db)
        {
            _db = db;
        }

        public bool Create(PaymentMethodViewModel pm)
        {
            _db.PaymentMethod.Add(new PaymentMethod 
            { 
                CardNumber = pm.CardNumber,
                CardExpirationMonth = pm.CardExpirationMonth,
                CardExpirationYear = pm.CardExpirationYear,
                CardCVV = pm.CardCVV,
                User_Id = pm.User_Id
            });
            _db.SaveChanges();
            return true;
        }

        public bool Delete(PaymentMethodViewModel pm)
        {
            _db.PaymentMethod.Remove(new PaymentMethod
            {
                Id = pm.Id,
                CardNumber = pm.CardNumber,
                CardExpirationMonth = pm.CardExpirationMonth,
                CardExpirationYear = pm.CardExpirationYear,
                CardCVV = pm.CardCVV,
                User_Id = pm.User_Id
            });
            _db.SaveChanges();
            return true;
        }

        public bool Edit(PaymentMethodViewModel pm)
        {
            _db.PaymentMethod.Update(new PaymentMethod
            {
                Id = pm.Id,
                CardNumber = pm.CardNumber,
                CardExpirationMonth = pm.CardExpirationMonth,
                CardExpirationYear = pm.CardExpirationYear,
                CardCVV = pm.CardCVV,
                User_Id = pm.User_Id
            });
            _db.SaveChanges();
            return true;
        }

        public async Task<IEnumerable<PaymentMethodViewModel>> GetAll()
        {
            return await (from pm in _db.PaymentMethod
                          select new PaymentMethodViewModel
                          {
                              Id = pm.Id,
                              CardNumber = pm.CardNumber,
                              CardExpirationMonth = pm.CardExpirationMonth,
                              CardExpirationYear = pm.CardExpirationYear,
                              CardCVV = pm.CardCVV,
                              User_Id = pm.User_Id
                          }).ToListAsync();
        }

        public async Task<PaymentMethodViewModel> GetById(int Id)
        {
            return await (from pm in _db.PaymentMethod
                          where pm.Id == Id
                          select new PaymentMethodViewModel
                          {
                              Id = pm.Id,
                              CardNumber = pm.CardNumber,
                              CardExpirationMonth = pm.CardExpirationMonth,
                              CardExpirationYear = pm.CardExpirationYear,
                              CardCVV = pm.CardCVV,
                              User_Id = pm.User_Id
                          }).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<PaymentMethodViewModel>> GetByUserId(int Id)
        {
            return await (from pm in _db.PaymentMethod
                          where pm.User_Id == Id
                          select new PaymentMethodViewModel
                          {
                              Id = pm.Id,
                              CardNumber = pm.CardNumber,
                              CardExpirationMonth = pm.CardExpirationMonth,
                              CardExpirationYear = pm.CardExpirationYear,
                              CardCVV = pm.CardCVV,
                              User_Id = pm.User_Id
                          }).ToListAsync();
        }
    }
}
