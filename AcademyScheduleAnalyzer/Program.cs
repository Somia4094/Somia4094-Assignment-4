using System;
using System.Text;
using BenchmarkDotNet.Running;

namespace Assignment4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // =========================================================
            // Part 1 - Session Data
            // =========================================================

            string[] sessionNames =
            {
                "C# Basics",
                "Arrays",
                "Functions",
                "Date and Time",
                "Exception Handling"
            };

            DateTime[] sessionDates =
            {
                new DateTime(2026, 9, 10, 18, 0, 0),
                new DateTime(2026, 9, 13, 18, 0, 0),
                new DateTime(2026, 9, 17, 18, 0, 0),
                new DateTime(2026, 9, 20, 18, 0, 0),
                new DateTime(2026, 9, 24, 18, 0, 0)
            };

            int[] sessionDurations =
            {
                180,
                240,
                180,
                240,
                180
            };


            // =========================================================
            // Part 2 - Display and Search Sessions
            // =========================================================

            static void DisplayAllSessions(
                string[] sessionNames,
                DateTime[] sessionDates,
                int[] sessionDurations)
            {
                for (int i = 0; i < sessionNames.Length; i++)
                {
                    Console.WriteLine(
                        $"{i + 1}. {sessionNames[i]}\r\n" +
                        $"Date: {sessionDates[i]:dd MMMM yyyy}\r\n" +
                        $"Start Time: {sessionDates[i]:hh:mm tt}\r\n" +
                        $"Duration: {sessionDurations[i]} minutes\r\n");
                }
            }


            static void SearchSession(
                string searchName,
                string[] sessionNames,
                DateTime[] sessionDates,
                int[] sessionDurations)
            {
                if (string.IsNullOrWhiteSpace(searchName))
                {
                    Console.WriteLine("Please enter the session name.");
                    return;
                }

                int index = Array.FindIndex(
                    sessionNames,
                    name => string.Equals(
                        searchName,
                        name,
                        StringComparison.OrdinalIgnoreCase));

                if (index != -1)
                {
                    Console.WriteLine(
                        $"{index + 1}. {sessionNames[index]}\r\n" +
                        $"Date: {sessionDates[index]:dd MMMM yyyy}\r\n" +
                        $"Start Time: {sessionDates[index]:hh:mm tt}\r\n" +
                        $"Duration: {sessionDurations[index]} minutes\r\n");
                }
                else
                {
                    Console.WriteLine("Session not found.");
                }
            }


            // =========================================================
            // Part 3 - Session Details
            // =========================================================

            static void DisplaySessionDetails(
                int index,
                string[] sessionNames,
                DateTime[] sessionDates,
                int[] sessionDurations)
            {
                Console.WriteLine(
                    $"{index + 1}. {sessionNames[index]}\r\n" +
                    $"Date: {sessionDates[index]:dd MMMM yyyy}\r\n" +
                    $"Start Time: {sessionDates[index]:hh:mm tt}\r\n" +
                    $"Duration: {sessionDurations[index]} minutes");
            }


            static DateTime GetSessionEndTime(
                int index,
                DateTime[] sessionDates,
                int[] sessionDurations)
            {
                return sessionDates[index].AddMinutes(sessionDurations[index]);
            }


            // =========================================================
            // Part 4 - Array Methods
            // =========================================================

            static void RunArrayMethods(
                string[] sessionNames)
            {
                // 4.1 Sort
                string[] sortedNames =
                    new string[sessionNames.Length];

                Array.Copy(
                    sessionNames,
                    sortedNames,
                    sessionNames.Length);

                Array.Sort(sortedNames);

                Console.WriteLine("Sorted session names:");

                foreach (string name in sortedNames)
                {
                    Console.WriteLine(name);
                }


                // 4.2 Reverse
                string[] reversedNames =
                    new string[sessionNames.Length];

                Array.Copy(
                    sessionNames,
                    reversedNames,
                    sessionNames.Length);

                Array.Reverse(reversedNames);

                Console.WriteLine("\nReversed session names:");

                foreach (string name in reversedNames)
                {
                    Console.WriteLine(name);
                }


                // 4.3 IndexOf
                Console.Write("\nEnter session name to find index: ");

                string inputSessionName =
                    Console.ReadLine();

                int index =
                    Array.IndexOf(
                        sessionNames,
                        inputSessionName);

                Console.WriteLine(
                    $"Index: {index}");


                // 4.4 Exists
                Console.Write("\nEnter session name to check: ");

                string sessionToCheck =
                    Console.ReadLine();

                bool exists =
                    Array.Exists(
                        sessionNames,
                        item => item.Equals(
                            sessionToCheck,
                            StringComparison.OrdinalIgnoreCase));

                Console.WriteLine(
                    exists
                        ? "Session exists."
                        : "Session does not exist.");


                // 4.5 Find
                string foundSession =
                    Array.Find(
                        sessionNames,
                        item => item.Equals(
                            "Date and Time",
                            StringComparison.OrdinalIgnoreCase));

                Console.WriteLine(
                    $"\nFound session: {foundSession}");


                // 4.6 FindIndex
                int foundSessionIndex =
                    Array.FindIndex(
                        sessionNames,
                        item => item.Equals(
                            "Functions",
                            StringComparison.OrdinalIgnoreCase));

                Console.WriteLine(
                    $"Functions index: {foundSessionIndex}");


                // 4.7 Copy
                string[] copiedNames =
                    new string[sessionNames.Length];

                Array.Copy(
                    sessionNames,
                    copiedNames,
                    sessionNames.Length);

                copiedNames[1] = "OOP";

                Console.WriteLine("\nOriginal array:");
                Console.WriteLine(
                    $"sessionNames[1] = {sessionNames[1]}");

                Console.WriteLine("Copied array:");
                Console.WriteLine(
                    $"copiedNames[1] = {copiedNames[1]}");
            }


            // =========================================================
            // Part 5 - Calculate Durations
            // =========================================================

            static int CalculateTotalDuration(
                int[] durations)
            {
                if (durations.Length == 0)
                {
                    return 0;
                }

                int totalDuration = 0;

                foreach (int duration in durations)
                {
                    totalDuration += duration;
                }

                return totalDuration;
            }


            static double CalculateAverageDuration(
                int[] durations)
            {
                if (durations.Length == 0)
                {
                    return 0;
                }

                int totalDuration = 0;

                foreach (int duration in durations)
                {
                    totalDuration += duration;
                }

                return (double)totalDuration / durations.Length;
            }


            static int CalculateShortestDuration(
                int[] durations)
            {
                if (durations.Length == 0)
                {
                    return 0;
                }

                int shortestDuration =
                    durations[0];

                for (int i = 0; i < durations.Length; i++)
                {
                    if (durations[i] < shortestDuration)
                    {
                        shortestDuration =
                            durations[i];
                    }
                }

                return shortestDuration;
            }


            static int CalculateLongestDuration(
                int[] durations)
            {
                if (durations.Length == 0)
                {
                    return 0;
                }

                int longestDuration =
                    durations[0];

                for (int i = 0; i < durations.Length; i++)
                {
                    if (durations[i] > longestDuration)
                    {
                        longestDuration =
                            durations[i];
                    }
                }

                return longestDuration;
            }


            // =========================================================
            // Part 6 - String and StringBuilder Reports
            // =========================================================

            static string BuildReportUsingString(
                string[] sessionNames,
                DateTime[] sessionDates,
                int[] sessionDurations)
            {
                string report = "";

                for (int i = 0;
                     i < sessionNames.Length;
                     i++)
                {
                    report +=
                        $"{i + 1}. {sessionNames[i]}\r\n";

                    report +=
                        $"Date: {sessionDates[i]:dd MMMM yyyy}\r\n";

                    report +=
                        $"Start Time: {sessionDates[i]:hh:mm tt}\r\n";

                    report +=
                        $"Duration: {sessionDurations[i]} minutes\r\n\r\n";
                }

                return report;
            }


            static string BuildReportUsingStringBuilder(
                string[] sessionNames,
                DateTime[] sessionDates,
                int[] sessionDurations)
            {
                StringBuilder report =
                    new StringBuilder();

                for (int i = 0;
                     i < sessionNames.Length;
                     i++)
                {
                    report.Append(
                        $"{i + 1}. {sessionNames[i]}\r\n");

                    report.Append(
                        $"Date: {sessionDates[i]:dd MMMM yyyy}\r\n");

                    report.Append(
                        $"Start Time: {sessionDates[i]:hh:mm tt}\r\n");

                    report.Append(
                        $"Duration: {sessionDurations[i]} minutes\r\n\r\n");
                }

                return report.ToString();
            }


            static DateTime ReadSessionDate()
            {
                Console.Write("Enter session date: ");

                return DateTime.Parse(
                    Console.ReadLine());
            }


            // =========================================================
            // Part 7 - ref / out / Reference Type
            // =========================================================

            static void ChangeNumber(
                ref int number)
            {
                number *= 2;
            }


            static bool FindSession(
                string findSessionName,
                string[] sessionNames,
                int[] sessionDurations,
                out int index,
                out int duration)
            {
                index = -1;
                duration = 0;

                for (int i = 0;
                     i < sessionNames.Length;
                     i++)
                {
                    if (sessionNames[i].Equals(
                        findSessionName,
                        StringComparison.OrdinalIgnoreCase))
                    {
                        index = i;
                        duration =
                            sessionDurations[i];

                        return true;
                    }
                }

                return false;
            }


            static void ChangeArray(
                int[] numbers)
            {
                numbers[0] = 70;
            }


            // =========================================================
            // Part 8 - params
            // =========================================================

            static int CalculateTotalNumbers(
                params int[] numbers)
            {
                int total = 0;

                foreach (int number in numbers)
                {
                    total += number;
                }

                return total;
            }


            // =========================================================
            // Part 9 - Date Details
            // =========================================================

            static void DisplayDetails(
                string sessionName,
                string[] sessionNames,
                DateTime[] sessionDates,
                int[] sessionDurations)
            {
                for (int i = 0;
                     i < sessionNames.Length;
                     i++)
                {
                    if (sessionNames[i].Equals(
                        sessionName,
                        StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine(
                            $"Full Date: {sessionDates[i]:dd MMMM yyyy}");

                        Console.WriteLine(
                            $"Day Of Week: {sessionDates[i].DayOfWeek}");

                        Console.WriteLine(
                            $"Year: {sessionDates[i].Year}");

                        Console.WriteLine(
                            $"Month: {sessionDates[i].Month}");

                        Console.WriteLine(
                            $"Day: {sessionDates[i].Day}");

                        Console.WriteLine(
                            $"Start Time: {sessionDates[i]:hh:mm tt}");

                        Console.WriteLine(
                            $"Duration: {sessionDurations[i]} minutes");

                        Console.WriteLine(
                            $"End Time: {sessionDates[i].AddMinutes(sessionDurations[i]):dd MMMM yyyy hh:mm tt}");

                        return;
                    }
                }

                Console.WriteLine("Session not found.");
            }


            // =========================================================
            // Part 10 - Date Difference
            // =========================================================

            static void DateDifference(
                string sessionName1,
                string sessionName2,
                string[] sessionNames,
                DateTime[] sessionDates)
            {
                int index1 = -1;
                int index2 = -1;

                for (int i = 0;
                     i < sessionNames.Length;
                     i++)
                {
                    if (sessionNames[i].Equals(
                        sessionName1,
                        StringComparison.OrdinalIgnoreCase))
                    {
                        index1 = i;
                    }

                    if (sessionNames[i].Equals(
                        sessionName2,
                        StringComparison.OrdinalIgnoreCase))
                    {
                        index2 = i;
                    }
                }

                if (index1 == -1 ||
                    index2 == -1)
                {
                    Console.WriteLine("Session not found.");
                    return;
                }

                TimeSpan difference =
                    sessionDates[index2] -
                    sessionDates[index1];

                Console.WriteLine(
                    $"First Session: {sessionName1}");

                Console.WriteLine(
                    $"Second Session: {sessionName2}");

                Console.WriteLine(
                    $"Difference: {difference.TotalDays} days");

                Console.WriteLine(
                    $"Difference: {difference.TotalHours} hours");
            }


            // =========================================================
            // Part 11 - Past / Upcoming
            // =========================================================

            static void ShowPastAndUpcoming(
                string[] sessionNames,
                DateTime[] sessionDates)
            {
                for (int i = 0;
                     i < sessionNames.Length;
                     i++)
                {
                    if (sessionDates[i] < DateTime.Now)
                    {
                        Console.WriteLine(
                            $"{sessionNames[i]} - Past");
                    }
                    else
                    {
                        Console.WriteLine(
                            $"{sessionNames[i]} - Upcoming");
                    }
                }
            }


            // =========================================================
            // Part 12 - Find Next Session
            // =========================================================

            static void FindNextSession(
                string[] sessionNames,
                DateTime[] sessionDates)
            {
                DateTime now =
                    DateTime.Now;

                DateTime nearestDate =
                    DateTime.MaxValue;

                int nearestIndex = -1;

                for (int i = 0;
                     i < sessionDates.Length;
                     i++)
                {
                    if (sessionDates[i] > now &&
                        sessionDates[i] < nearestDate)
                    {
                        nearestDate =
                            sessionDates[i];

                        nearestIndex =
                            i;
                    }
                }

                if (nearestIndex != -1)
                {
                    TimeSpan remaining =
                        nearestDate - now;

                    Console.WriteLine(
                        $"Next Session: {sessionNames[nearestIndex]}");

                    Console.WriteLine(
                        $"Date: {nearestDate:dd MMMM yyyy}");

                    Console.WriteLine(
                        $"Start Time: {nearestDate:hh:mm tt}");

                    Console.WriteLine(
                        $"Time Remaining: {remaining.Days} days {remaining.Hours} hours");
                }
                else
                {
                    Console.WriteLine(
                        "No upcoming sessions.");
                }
            }


            // =========================================================
            // Part 13 - Date Formatting
            // =========================================================

            static void ShowDateFormatting(
                string sessionName,
                string[] sessionNames,
                DateTime[] sessionDates)
            {
                int index =
                    Array.FindIndex(
                        sessionNames,
                        name => name.Equals(
                            sessionName,
                            StringComparison.OrdinalIgnoreCase));

                if (index == -1)
                {
                    Console.WriteLine(
                        "Session not found.");

                    return;
                }

                DateTime selectedDate =
                    sessionDates[index];

                Console.WriteLine(
                    selectedDate.ToString("yyyy-MM-dd"));

                Console.WriteLine(
                    selectedDate.ToString("dd/MM/yyyy"));

                Console.WriteLine(
                    selectedDate.ToString("dd MMMM yyyy"));

                Console.WriteLine(
                    selectedDate.ToString("dddd, dd MMMM yyyy"));

                Console.WriteLine(
                    selectedDate.ToString("hh:mm tt"));
            }


            // =========================================================
            // Part 14 - Read and Validate Date
            // =========================================================

            static DateTime ReadAndValidateDate()
            {
                DateTime date;

                while (true)
                {
                    Console.Write(
                        "Enter date (yyyy-MM-dd HH:mm): ");

                    string input =
                        Console.ReadLine();

                    bool isValid =
                        DateTime.TryParseExact(
                            input,
                            "yyyy-MM-dd HH:mm",
                            null,
                            System.Globalization.DateTimeStyles.None,
                            out date);

                    if (isValid)
                    {
                        return date;
                    }

                    Console.WriteLine(
                        "Invalid date. Please try again.");
                }
            }


            // =========================================================
            // Part 15 - Exception Handling: Menu Input
            // =========================================================

            static int ReadMenuOption()
            {
                while (true)
                {
                    Console.Write(
                        "Choose an option: ");

                    string input =
                        Console.ReadLine();

                    try
                    {
                        return int.Parse(input);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine(
                            "Invalid menu option. Enter a number.");
                    }
                }
            }


            // =========================================================
            // Part 16 - Invalid Array Index
            // =========================================================

            static void ReadSessionByIndex(
                string[] sessionNames)
            {
                Console.Write(
                    "Enter session index: ");

                string input =
                    Console.ReadLine();

                try
                {
                    int index =
                        int.Parse(input);

                    Console.WriteLine(
                        $"Session: {sessionNames[index]}");
                }
                catch (FormatException)
                {
                    Console.WriteLine(
                        "Please enter a valid number.");
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine(
                        "The selected session index is out of range.");
                }
            }


            // =========================================================
            // Part 17 - Throw an Exception
            // =========================================================

            static void ValidateDuration(
                int duration)
            {
                if (duration <= 0)
                {
                    throw new ArgumentException(
                        "Duration must be greater than zero.");
                }

                Console.WriteLine(
                    "Duration accepted.");
            }


            // =========================================================
            // Part 18 - finally
            // =========================================================

            static void RunFinallyDemo()
            {
                try
                {
                    Console.Write(
                        "Enter a number: ");

                    int value =
                        int.Parse(
                            Console.ReadLine());

                    Console.WriteLine(
                        $"You entered: {value}");
                }
                catch (FormatException)
                {
                    Console.WriteLine(
                        "Invalid number.");
                }
                finally
                {
                    Console.WriteLine(
                        "Input operation finished.");
                }
            }


            // =========================================================
            // Part 19 - Build Schedule Report Using string
            // =========================================================

            static string BuildScheduleReportUsingString(
                string[] sessionNames,
                DateTime[] sessionDates,
                int[] sessionDurations)
            {
                string result = "";

                for (int i = 0;
                     i < sessionNames.Length;
                     i++)
                {
                    result +=
                        $"{sessionNames[i]} - " +
                        $"{sessionDates[i]:dd/MM/yyyy hh:mm tt} - " +
                        $"{sessionDurations[i]} minutes\r\n";
                }

                return result;
            }


            // =========================================================
            // Part 20 - Build Same Report Using StringBuilder
            // =========================================================

            static string BuildScheduleReportUsingStringBuilder(
                string[] sessionNames,
                DateTime[] sessionDates,
                int[] sessionDurations)
            {
                StringBuilder result =
                    new StringBuilder();

                for (int i = 0;
                     i < sessionNames.Length;
                     i++)
                {
                    result.Append(
                        $"{sessionNames[i]} - " +
                        $"{sessionDates[i]:dd/MM/yyyy hh:mm tt} - " +
                        $"{sessionDurations[i]} minutes\r\n");
                }

                return result.ToString();
            }


            // =========================================================
            // Part 31 - Final Menu
            // =========================================================

            int choice;

            do
            {
                Console.WriteLine();
                Console.WriteLine(
                    "==============================================");

                Console.WriteLine(
                    "       Academy Schedule Analyzer");

                Console.WriteLine(
                    "==============================================");

                Console.WriteLine("1.  Display All Sessions");
                Console.WriteLine("2.  Search Session");
                Console.WriteLine("3.  Session Details");
                Console.WriteLine("4.  Array Methods");
                Console.WriteLine("5.  Calculate Durations");
                Console.WriteLine("6.  String and StringBuilder Reports");
                Console.WriteLine("7.  ref / out / Reference Type");
                Console.WriteLine("8.  params");
                Console.WriteLine("9.  Date Details");
                Console.WriteLine("10. Date Difference");
                Console.WriteLine("11. Past / Upcoming");
                Console.WriteLine("12. Find Next Session");
                Console.WriteLine("13. Date Formatting");
                Console.WriteLine("14. Read and Validate Date");
                Console.WriteLine("15. Exception Handling");
                Console.WriteLine("16. Invalid Array Index");
                Console.WriteLine("0.  Exit");

                choice =
                    ReadMenuOption();

                Console.WriteLine();

                switch (choice)
                {
                    case 1:

                        DisplayAllSessions(
                            sessionNames,
                            sessionDates,
                            sessionDurations);

                        break;


                    case 2:

                        Console.Write(
                            "Enter session name: ");

                        string searchName =
                            Console.ReadLine();

                        SearchSession(
                            searchName,
                            sessionNames,
                            sessionDates,
                            sessionDurations);

                        break;


                    case 3:

                        Console.Write(
                            "Enter session index: ");

                        try
                        {
                            int index =
                                int.Parse(
                                    Console.ReadLine());

                            DisplaySessionDetails(
                                index,
                                sessionNames,
                                sessionDates,
                                sessionDurations);

                            Console.WriteLine(
                                $"End Time: {GetSessionEndTime(index, sessionDates, sessionDurations):dd MMMM yyyy hh:mm tt}");
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine(
                                "Please enter a valid number.");
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Console.WriteLine(
                                "The selected session index is out of range.");
                        }

                        break;


                    case 4:

                        RunArrayMethods(
                            sessionNames);

                        break;


                    case 5:

                        Console.WriteLine(
                            $"Total Duration: {CalculateTotalDuration(sessionDurations)} minutes");

                        Console.WriteLine(
                            $"Average Duration: {CalculateAverageDuration(sessionDurations)} minutes");

                        Console.WriteLine(
                            $"Shortest Duration: {CalculateShortestDuration(sessionDurations)} minutes");

                        Console.WriteLine(
                            $"Longest Duration: {CalculateLongestDuration(sessionDurations)} minutes");


                        int[] copyNumbers =
                            new int[sessionDurations.Length];

                        Array.Copy(
                            sessionDurations,
                            copyNumbers,
                            sessionDurations.Length);

                        Array.Sort(copyNumbers);

                        Console.WriteLine(
                            "Sorted durations:");

                        foreach (int duration in copyNumbers)
                        {
                            Console.WriteLine(duration);
                        }

                        break;


                    case 6:

                        Console.WriteLine(
                            "Report using string:");

                        Console.WriteLine(
                            BuildReportUsingString(
                                sessionNames,
                                sessionDates,
                                sessionDurations));

                        Console.WriteLine(
                            "Report using StringBuilder:");

                        Console.WriteLine(
                            BuildReportUsingStringBuilder(
                                sessionNames,
                                sessionDates,
                                sessionDurations));

                        Console.WriteLine(
                            "Schedule report using string:");

                        Console.WriteLine(
                            BuildScheduleReportUsingString(
                                sessionNames,
                                sessionDates,
                                sessionDurations));

                        Console.WriteLine(
                            "Schedule report using StringBuilder:");

                        Console.WriteLine(
                            BuildScheduleReportUsingStringBuilder(
                                sessionNames,
                                sessionDates,
                                sessionDurations));

                        break;


                    case 7:

                        // ref
                        int number = 10;

                        Console.WriteLine(
                            $"Before ref: {number}");

                        ChangeNumber(
                            ref number);

                        Console.WriteLine(
                            $"After ref: {number}");


                        // out
                        Console.Write(
                            "\nEnter session name for out demo: ");

                        string findSessionName =
                            Console.ReadLine();

                        bool found =
                            FindSession(
                                findSessionName,
                                sessionNames,
                                sessionDurations,
                                out int sessionIndex,
                                out int sessionDuration);

                        if (found)
                        {
                            Console.WriteLine(
                                $"Index: {sessionIndex}");

                            Console.WriteLine(
                                $"Duration: {sessionDuration} minutes");
                        }
                        else
                        {
                            Console.WriteLine(
                                "Session not found.");
                        }


                        // Reference type without ref
                        int[] numbers =
                        {
                            10,
                            20,
                            30
                        };

                        Console.WriteLine(
                            "\nBefore changing array:");

                        foreach (int value in numbers)
                        {
                            Console.WriteLine(value);
                        }

                        ChangeArray(numbers);

                        Console.WriteLine(
                            "After changing array:");

                        foreach (int value in numbers)
                        {
                            Console.WriteLine(value);
                        }

                        break;


                    case 8:

                        Console.WriteLine(
                            $"Total 1: {CalculateTotalNumbers(10, 20)}");

                        Console.WriteLine(
                            $"Total 2: {CalculateTotalNumbers(10, 20, 30, 40)}");

                        Console.WriteLine(
                            $"Total 3: {CalculateTotalNumbers(120, 180, 240, 100, 1000)}");

                        break;


                    case 9:

                        Console.Write(
                            "Enter session name: ");

                        string detailsName =
                            Console.ReadLine();

                        DisplayDetails(
                            detailsName,
                            sessionNames,
                            sessionDates,
                            sessionDurations);

                        break;


                    case 10:

                        Console.Write(
                            "Enter first session name: ");

                        string sessionName1 =
                            Console.ReadLine();

                        Console.Write(
                            "Enter second session name: ");

                        string sessionName2 =
                            Console.ReadLine();

                        DateDifference(
                            sessionName1,
                            sessionName2,
                            sessionNames,
                            sessionDates);

                        break;


                    case 11:

                        ShowPastAndUpcoming(
                            sessionNames,
                            sessionDates);

                        break;


                    case 12:

                        FindNextSession(
                            sessionNames,
                            sessionDates);

                        break;


                    case 13:

                        Console.Write(
                            "Enter session name: ");

                        string formattingName =
                            Console.ReadLine();

                        ShowDateFormatting(
                            formattingName,
                            sessionNames,
                            sessionDates);

                        break;


                    case 14:

                        DateTime validDate =
                            ReadAndValidateDate();

                        Console.WriteLine(
                            $"Valid Date: {validDate:yyyy-MM-dd HH:mm}");

                        break;


                    case 15:

                        Console.Write(
                            "Enter duration: ");

                        string durationInput =
                            Console.ReadLine();

                        try
                        {
                            int duration =
                                int.Parse(durationInput);

                            ValidateDuration(
                                duration);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine(
                                "Please enter a valid number.");
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(
                                ex.Message);
                        }
                        finally
                        {
                            Console.WriteLine(
                                "Duration operation finished.");
                        }

                        Console.WriteLine();

                        RunFinallyDemo();

                        break;


                    case 16:

                        ReadSessionByIndex(
                            sessionNames);

                        break;


                    case 0:

                        Console.WriteLine(
                            "Exiting...");

                        break;


                    default:

                        Console.WriteLine(
                            "Invalid option. Choose a number from 0 to 16.");

                        break;
                }

            } while (choice != 0);


            // =========================================================
            // Benchmark
            // =========================================================

            BenchmarkRunner.Run<StringBenchmark>();
        }
    }
}