using System;
using System.Collections.Generic;

namespace Cyotek.SvnMigrate
{
  internal static class SortHelpers
  {
    #region Public Methods

    public static void QuickSort<T>(IList<T> values, Comparison<T> comparison)
    {
      if (values.Count > 0)
      {
        SortHelpers.QuickSort(values, comparison, 0, values.Count - 1);
      }
    }

    #endregion Public Methods

    #region Private Methods

    private static void QuickSort<T>(IList<T> values, Comparison<T> comparison, int left, int right)
    {
      int i = left;
      int j = right;
      T pivot;

      // https://stackoverflow.com/a/15325195/148962

      pivot = values[(left + right) / 2];

      while (i <= j)
      {
        while (comparison(values[i], pivot) < 0)
        {
          i++;
        }

        while (comparison(values[j], pivot) > 0)
        {
          j--;
        }

        if (i <= j)
        {
          T temp = values[i];
          values[i++] = values[j];
          values[j--] = temp;
        }
      }

      if (left < j)
      {
        SortHelpers.QuickSort(values, comparison, left, j);
      }

      if (i < right)
      {
        SortHelpers.QuickSort(values, comparison, i, right);
      }
    }

    #endregion Private Methods
  }
}