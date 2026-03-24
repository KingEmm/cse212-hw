using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {
        // TODO Problem 1 - ADD YOUR CODE HERE
        // for(int i=0; i<words.Count(); i++)
        // {
            
        // }

        var set = new HashSet<string>();
        var wordComp= new List<string>();
        foreach(var word in words)
        {
            var lt = word[0];
            var rt = word[1];
            var sum = lt + rt;
            if (set.Contains($"{rt}{lt}"))
            {
                string wd = $"{word[0]}{word[1]} & {word[1]}{word[0]}";
                if(!wordComp.Contains(wd))
                    wordComp.Add($"{word[0]}{word[1]} & {word[1]}{word[0]}");
            }
            else
            {
                set.Add($"{lt}{rt}");
            }
        }
        if(wordComp.Count()>3)
            return wordComp.Slice(0,3).ToArray();
        return wordComp.ToArray();
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            // TODO Problem 2 - ADD YOUR CODE HERE
            if(degrees.ContainsKey(fields[3]))
                degrees[fields[3]] += 1; //int.Parse(fields[4]);
            else
                degrees.Add(fields[3], 1); //int.Parse(fields[4]));
        }
        Debug.WriteLine($"Players: {{{string.Join(", ", degrees)}}}");
        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static KeyValuePair<int, char> GetNextItem(string word, int ind)
    {
        if(word[ind] == ' ')
        {
            ind++;
            return GetNextItem(word, ind);
        }
        return new KeyValuePair<int, char>(ind, word[ind]); 
    }
    public static bool IsAnagram(string word1, string word2)
    {
        // var len1 = word1.Length;
        // var len2 = word2.Length;
        // if(len1 > 50000 && len2 > 50000)
        // {
        //     len1 = 50000;
        //     len2 = 50000;
        // }
        var pair1 = new Dictionary<int, char>();
        var pair2 = new Dictionary<int, char>();
        int tot1 = 0;
        int to1=0;
        int to2=0;
        // int tot2 = 0;
        int j=0;
        for(int i=0; i+to1 != word1.Length; i++) //word1.Length; i++)
        {
            try
            {
                // if (word1[i+to1] == ' ')
                // {
                //     to1 += 1;                
                // }
                // if (word2[j+to2] == ' ')
                // {
                //     to2 += 1;
                // }
                var wd1 = GetNextItem(word1, i+to1);
                var wd2 = GetNextItem(word2, i+to2);
                pair1.Add(i, char.Parse(wd1.Value.ToString().ToLower()));//.ToString().ToLower()); //word1[i+to1].ToString().ToLower());
                pair2.Add(j, char.Parse(wd2.Value.ToString().ToLower()));//.ToString().ToLower()); //word2[j+to2].ToString().ToLower());
                if(wd1.Value == wd2.Value)
                    tot1 +=1;
                to1 = wd1.Key-i;
                to2 = wd2.Key-j;
                j++;
            }
            catch(ArgumentException e)
            {
                Debug.WriteLine(e);
                return false;
            }
            catch(IndexOutOfRangeException e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }

        if(pair1.Count + to1 != word1.Length)
        {
            return false;
        }
        if(pair2.Count + to2 != word2.Length)
        {
            return false;
        }
        if(tot1+to1 == word1.Length)
            return true;

        tot1 = 0;

        var par1=pair1.ToArray();
        Array.Sort(par1, (p1, p2)=> p1.Value - p2.Value);
        var par2=pair2.ToArray();
        Array.Sort(par2, (p1, p2)=> p1.Value - p2.Value);
        
        for(int k=0; k < pair1.Count(); k++)
        {
            if ($"{par1[k].Value}" == $"{par2[k].Value}")
            {
                Console.WriteLine(par1[k]);
                tot1 += 1;
            }
        }
        if(tot1 == pair1.Count())  
            return true;
        // TODO Problem 3 - ADD YOUR CODE HERE
        return false;
    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        // TODO Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place a earthquake has happened today and its magitude.
        // 3. Return an array of these string descriptions.
        List<string> strings  =  new List<string>();
        foreach(var feature in featureCollection.features)
        {
            string prop = $"Place - {feature.properties.place} - Mag {feature.properties.mag} ";
            Debug.WriteLine(prop);
            strings.Add(prop);
        }
        return strings.ToArray();
    }
}