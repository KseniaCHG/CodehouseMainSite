using Codehouse.Automation.Common.Support;
using OpenQA.Selenium;

namespace Codehouse.Automation.Common.Extensions;

public static class SearchContextExtensions
{
    public static IWebElement WaitForAndFindElement(this ISearchContext searchContext, By locator, ElementQuery query, WaitSettings settings)
    {
        return searchContext.WaitUntil(sc => sc.FindElements(locator).FirstOrDefault(query.Compare), settings);
    }

    public static IWebElement WaitForAndFindElement(this ISearchContext searchContext, By locator, ElementQuery query)
    {
        return searchContext.WaitUntil(sc => sc.FindElements(locator).FirstOrDefault(query.Compare));
    }

    public static IWebElement WaitForAndFindElement(this ISearchContext searchContext, By locator, WaitSettings settings)
    {
        return searchContext.WaitUntil(sc => sc.FindElements(locator).FirstOrDefault(), settings);
    }

    public static IWebElement WaitForAndFindElement(this ISearchContext searchContext, By locator)
    {
        return searchContext.WaitUntil(sc => sc.FindElements(locator).FirstOrDefault());
    }

    public static List<IWebElement> WaitForAndFindElements(this ISearchContext searchContext, By locator, ElementQuery query, WaitSettings settings)
    {
        return searchContext.WaitUntil(
            sc =>
            {
                var collection = sc.FindElements(locator).Where(query.Compare).ToList();
                return collection.Any() ? collection : null;
            },
            settings);
    }

    public static List<IWebElement> WaitForAndFindElements(this ISearchContext searchContext, By locator, ElementQuery query)
    {
        return searchContext.WaitUntil(
            sc =>
            {
                var collection = sc.FindElements(locator).Where(query.Compare).ToList();
                return collection.Any() ? collection : null;
            });
    }

    public static List<IWebElement> WaitForAndFindElements(this ISearchContext searchContext, By locator, WaitSettings settings)
    {
        return searchContext.WaitUntil(
            sc =>
            {
                var collection = sc.FindElements(locator).ToList();
                return collection.Any() ? collection : null;
            },
            settings);
    }

    public static List<IWebElement> WaitForAndFindElements(this ISearchContext searchContext, By locator)
    {
        return searchContext.WaitUntil(
            sc =>
            {
                var collection = sc.FindElements(locator).ToList();
                return collection.Any() ? collection : null;
            });
    }

    private static T WaitUntil<T>(this ISearchContext searchContext, Func<ISearchContext, T?> function, WaitSettings settings)
    {
        return new ConfiguredDefaultWait<ISearchContext>(searchContext, settings).Until(function)!;
    }

    private static T WaitUntil<T>(this ISearchContext searchContext, Func<ISearchContext, T?> function)
    {
        return new ConfiguredDefaultWait<ISearchContext>(searchContext).Until(function)!;
    }
}