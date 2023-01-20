using System.ComponentModel.DataAnnotations;

namespace elfbar_shop.Domain.Response
{
    public enum StatusCodes
    {
        OK = 200,
        InternalError = 500,
        DataIsEmpty = 501
    }
}