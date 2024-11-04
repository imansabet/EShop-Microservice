using Grpc.Core;

namespace Discount.Grpc.Services;

public class DiscountService : DiscountProtoService.DiscountProtoServiceBase
{
    public override Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
    {
        return base.GetDiscount(request, context);
    }
    public override Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
    {
        return base.CreateDiscount(request, context);
    }
    public override Task<CouponModel> updateDiscount(UpdateDiscountRequest request, ServerCallContext context)
    {
        return base.updateDiscount(request, context);
    }
    public override Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
    {
        return base.DeleteDiscount(request, context);
    }
} 
