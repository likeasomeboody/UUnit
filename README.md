# UnityUnit

A testing framework designed for Unity C# with additional features.

## Motivation

As a general rule testing makes software better structured, more maintanable, more shareable and more reliable. It makes refactors and reworks of critical code less risky.

Unity's stock NUnit test tools are very helpful for defining and running tests from within unity. Playmode tests are exceptional for running tests on components that are meant to exhibit behaviour but far from complete

## Objectives

Unity Unit is intended to be an open source Test runner with a focus on Unity C# development. It aims to:
 * Add many of the unit testing features available to current testing frameworks that are sorely lacking in Unity
 * Provide a runner for unity tests that does not explicitly require the Unity Editor
 * Last but not least it is to be easily modified to add more functionality and additional behaviour.  

## Planned Releases:

### UnityTest 0.1:
 *	Unity Test Runner editor
 *  Minimum viable support for standard NUnit Tests 
 *	Minimum viable support for UnityTests
 *	Unity batch mode commands
 * Command line test runner that works with NUnit Tests

### UnityTest 0.2:
 *	Code coverage evaluation and UI reporting in 

### UnityTest 0.3:
 * NUnit Test report generation module
 * JUnit Test report generation module

### UnityTest 0.4:
 *	Cobertura code coverage report generation
 * OpenCover code coverage report generation with ReportGenerator

### UnityTest 0.5:
 * Scene test components for running tests dependent on a particular scene
 * Scene test runner editor 
 

