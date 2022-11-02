using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CustomStringEnumerator.Tests
{
    // Do not change the name of this class
    public class CustomStringEnumerator :  IEnumerable<string>
    {
        private IEnumerable _list;
        private EnumeratorConfig _config;
    
        /// <summary> Constructor </summary>
        /// <exception cref="System.ArgumentNullException">If a collection is null</exception>
        /// <exception cref="System.ArgumentNullException">If an config is null</exception>
        public CustomStringEnumerator(IEnumerable<string> collection, EnumeratorConfig config)
        {
            if (collection == null)
                throw new ArgumentNullException();

            if (config == null)
                throw new ArgumentNullException();

            _list = collection;
            _config = config;
        }

        public IEnumerator<string> GetEnumerator()
        {
            yield return "";
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}





// Your implementation of CustomStringEnumerator should take into account all the properties of EnumeratorConfig
public class EnumeratorConfig
{
    // Specifies the minimal length of strings that should be returned by a custom enumerator.
    // If it is set to negative value then this option is ignored.
    public int MinLength { get; set; } = -1;

    // Specifies the maximum length of strings that should be returned by a custom enumerator.
    // If it is set to negative value then this option is ignored.
    public int MaxLength { get; set; } = -1;

    // Specifies that only strings that start with a capital letter should be returned by a custom enumerator.
    // Please note that empty or null strings do not meet this condition.
    public bool StartWithCapitalLetter { get; set; }

    // Specifies that only strings that start with a digit should be returned by a custom enumerator.
    // Please note that empty or null strings do not meet this condition.
    public bool StartWithDigit { get; set; }
}

