<h3>Ordered Jobs Kata</h3>

Imagine we have a list of jobs, each represented by a character. Because certain jobs must be done before others, a job may have a dependency on another job. For example, a may depend on b, meaning the final sequence of jobs should place b before a. If a has no dependency, the position of a in the final sequence does not matter.

The goal of the kata is to parse the job dependency structure and produce a sequence of jobs in the order that observes their dependency chain.

Start with a method that accepts a single string argument and returns a string which represents the ordered sequence of jobs (since each job is a single character). We’ll refine the algorithm by evolving the requirements with each step, just like the string calculator kata.

<strong>Step 1 – Empty String</strong>

Given you’re passed an empty string (no jobs), the result should be an empty sequence.

<strong>Step 2 – Single Job</strong>

Given the following job structure:

a =>
The result should be a sequence consisting of a single job a.

<strong>Step 3 – Multiple Jobs</strong>

Given the following job structure:

a =>
b =>
c =>
The result should be a sequence containing all three jobs abc in no significant order.

<strong>Step 4 – Multiple Jobs, Single Dependency</strong>

Given the following job structure:

a =>
b => c
c =>
The result should be a sequence that positions c before b, containing all three jobs abc.




<strong>Step 5 – Multiple Jobs, Multiple Dependencies</strong>

Given the following job structure:

a =>
b => c
c => f
d => a
e => b
f =>
The result should be a sequence that positions f before c, c before b, b before e and a before d containing all six jobs abcdef.

<strong>Step 6 – Multiple Jobs, Self Referencing Dependency</strong>

Given the following job structure:

a =>
b =>
c => c
The result should be an error stating that jobs can’t depend on themselves.

<strong>Step 7 – Multiple Jobs, Circular Dependency Chain</strong>

Given the following job structure:

a =>
b => c
c => f
d => a
e =>
f => b
The result should be an error stating that jobs can’t have circular dependencies.
