open System

let Otvet k =    
   match k with 
   |1|2 -> System.Console.WriteLine("Поздравляю, Вы - подлиза!")
   |3 -> System.Console.WriteLine("Ты молодец!")
   |4 -> System.Console.WriteLine("Изучай новое!")
   |5 -> System.Console.WriteLine("Серьезные вещи!")
   |6 -> System.Console.WriteLine("Мощно!")
   | _ ->System.Console.WriteLine("Интересный выбор...")

[<EntryPoint>]
let main argv =
   System.Console.WriteLine("Какой ваш любимый язык программирования?
   1 F#
   2 Prolog
   3 C++
   4 Pascal
   5 C#
   6 Python")
   let k=System.Convert.ToInt32(System.Console.ReadLine())
   Otvet k 
   0


