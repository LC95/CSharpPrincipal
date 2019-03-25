using CSharpPrinciple;

namespace PrincipalUseCase {
    /// <summary>
    /// 原则1 : 使用隐式类型的局部变量
    /// </summary>
    public class UseCase1 {
        public void GetProduct()
        {
            var product = ProductService.GetProduct();
        }
    }

    /// <summary>
    /// 原则2 : 选用readonly而不是const
    /// </summary>
    public class UseCase2 {
        //C#含有两种常量, 编译时常量和运行时常量, 你应当选用运行时常量而不是编译时常量
        //编译时常量稍快一点, 但是缺少了更多的灵活性.
        public static readonly int ThisYear = 2004;
        //const可以定义在方法当中, 但是readonly不可以
        //运行时常量支持所有类型, 编译时常量支持数字, 枚举, 字符串
        // public const DateTime Min = DateTime.MinValue; Wrong!
    }

    /// <summary>
    /// 原则3 : 选用is or as 运算符来进行转换
    /// </summary>
    public class UseCase3 {
        public void Good()
        {
            object p = ProductService.GetProduct();
            var product = p as Product;
            if (product != null)
            {
                //转换成功
            }
            else
            {
                //转换失败
            }
        }

        public void Bad()
        {
            object o = ProductService.GetProduct();
            try
            {
                var p = (Product)o;
            }
            catch
            {
                //Throw Exception
            }
        }
    }

    /// <summary>
    /// 原则4 : 使用$运算符实现内插字符串
    /// </summary>
    public class UseCase4 {
        private void Print()
        {
            var s = $"The type is {GetType()}";
            //等价于string.Format("{0}",GetType())
        }
    }
}