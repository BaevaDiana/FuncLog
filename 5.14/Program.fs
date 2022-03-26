open System

let obxod n func init=
   let rec obxod1 n func init b=
       if b=0 then init else
       let newInit= if n%b=0 then func init b else init
       let newb=b-1
       obxod1 n func newInit newb 
   obxod1 n func init n

[<EntryPoint>]
let main argv =
   System.Console.WriteLine("Введите число:")
   let a=System.Convert.ToInt32(System.Console.ReadLine())
   System.Console.WriteLine("Произведение делителей числа:{0}", obxod a (fun x y -> x*y ) 1)
   0 