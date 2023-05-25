# Exercises for CSharpFunctionalExtensions
In the file Cases.cs are some excercises for the CSharpFunctionalExtensions library.  
The goal is to have only one expression per method and never call `Result.Success` or `Result.Failure` manually.  
Run the tests to validate your result.  

You will need the following methods from CSharpFunctionalExtensions:
- [Bind](https://github.com/vkhorikov/CSharpFunctionalExtensions/blob/master/CSharpFunctionalExtensions/Result/Methods/Extensions/Bind.cs)
- [Map](https://github.com/vkhorikov/CSharpFunctionalExtensions/blob/master/CSharpFunctionalExtensions/Result/Methods/Extensions/Map.cs)
- [MapError](https://github.com/vkhorikov/CSharpFunctionalExtensions/blob/master/CSharpFunctionalExtensions/Result/Methods/Extensions/MapError.cs)
- [Tap](https://github.com/vkhorikov/CSharpFunctionalExtensions/blob/master/CSharpFunctionalExtensions/Result/Methods/Extensions/Tap.cs)
- [Check](https://github.com/vkhorikov/CSharpFunctionalExtensions/blob/master/CSharpFunctionalExtensions/Result/Methods/Extensions/Check.cs)
- [Combine](https://github.com/vkhorikov/CSharpFunctionalExtensions/blob/master/CSharpFunctionalExtensions/Result/Methods/Extensions/Combine.cs)

Try to learn how to read the signature of those methods. Look out for their inputs and what they do to the outputs.  
Then try to apply them to the exercises.