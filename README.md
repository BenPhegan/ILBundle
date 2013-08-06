ILBundle
========

ILMerge without the "merge".

What
====

Simple NuGet package that does two things:

1. Adds a class that provides an overload the AppDomain.CurrentDomain.AssemblyResolve event, and some code to load assemblies out of resources.  For more details have a look [here](http://blogs.msdn.com/b/microsoft_press/archive/2010/02/03/jeffrey-richter-excerpt-2-from-clr-via-c-third-edition.aspx) and [here](http://research.microsoft.com/en-us/people/mbarnett/ilmerge.aspx)
2. Adds an MSBuild target that embeds all required assemblies into the output file as a set of Resources for resolution by the class above.

This essentially means that you automatically get an assembly/exe out of your build that has the required code and all required dependencies "bundled" together, without any IL merging.

How
===

1. Add the ILBundle package to your output project.  This will add the ILBundle.cs class and the ILBundle.targets MSBuild target (at least, it should!).
2. Add a call to ILBundle.RegisterAssemblyResolver() to your main entry point.  This pretty much has to be the first thing that runs.  Also better if anything that requires a dependent assembly does not run in the same method.

Caveats
=======

1. Mostly works on my machine.
2. Not saying it will work on yours.
3. May break random bits of your world, but that is unintentional.
4. Consider it a cute hack that generally just seems to work, but sometimes won't.
