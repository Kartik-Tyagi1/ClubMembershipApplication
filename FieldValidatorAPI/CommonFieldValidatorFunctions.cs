using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace FieldValidatorAPI
{
    /*
     * Delegate Types that will be used to reference validation functions 
     */

    // Delegate type that can reference a method used for the purpose ensuring that a form field is not left empty
    public delegate bool RequiredValidDel(string fieldVal);

    // Delegate type that can reference a method used for the purpose of validating the character length of a text field is between a min and max length inclusive
    public delegate bool StringLenValidDel(string fieldVal, int minLength, int maxLength);

    // Delegate type that can reference a method used for the purpose of validating the inputted date
    public delegate bool DateValidDel(string fieldVal, out DateTime validDateTime);

    // Delegate type that can reference a method used for the purpose of validating text input field value against a regex pattern
    public delegate bool PatternMatchValidDel(string fieldValid, string regexPattern);

    // Delegate type that can reference a method used for the purpose of validating a text field value against another text field value
    public delegate bool CompareFieldsValidDel(string fieldValid, string fieldValCompare);
    
    public class CommonFieldValidatorFunctions
    {
        private static RequiredValidDel _requiredValidDel = null;
        private static StringLenValidDel _stringLenValidDel = null;
        private static DateValidDel _dateValidDel = null;
        private static PatternMatchValidDel _patternMatchDel = null;
        private static CompareFieldsValidDel _compareFieldsValidDel = null;

        #region Public Getters for Delegates (Singletons)
        public static RequiredValidDel RequiredFieldValidDel
        {
            get
            {
                if (_requiredValidDel == null)
                    _requiredValidDel = new RequiredValidDel(RequiredFieldValid);

                return _requiredValidDel;
            }
        }

        public static StringLenValidDel StringFieldLengthValidDel
        {
            get
            {
                if (_stringLenValidDel == null)
                    _stringLenValidDel = new StringLenValidDel(StringFieldLengthValid);

                return _stringLenValidDel;
            }
        }

        public static DateValidDel DateFieldValidDel
        {
            get
            {
                if (_dateValidDel == null)
                    _dateValidDel = new DateValidDel(DateFieldValid);

                return _dateValidDel;
            }
        }

        public static PatternMatchValidDel PatternMatchValidDel
        {
            get
            {
                if (_patternMatchDel == null)
                    _patternMatchDel = new PatternMatchValidDel(PatternMatchFieldValid);

                return _patternMatchDel;
            }
        }

        public static CompareFieldsValidDel CompareFieldsValidDel
        {
            get
            {
                if (_compareFieldsValidDel == null)
                    _compareFieldsValidDel = new CompareFieldsValidDel(CompareFieldsValid);

                return _compareFieldsValidDel;
            }
        }
        #endregion

        #region Private Functions That Delegates Will Reference

        private static bool RequiredFieldValid(string fieldVal)
        {
            if(!string.IsNullOrEmpty(fieldVal)) return true;

            return false;
        }

        private static bool StringFieldLengthValid(string fieldVal, int minLength, int maxLength)
        {
            if (fieldVal.Length >= minLength || fieldVal.Length <= maxLength) return true;

            return false;
        }

        private static bool DateFieldValid(string fieldVal, out DateTime validDateTime)
        {
            if (DateTime.TryParse(fieldVal, out validDateTime)) return true;

            return false;
        }

        private static bool PatternMatchFieldValid(string fieldValid, string regexPattern)
        {
            Regex regex = new Regex(regexPattern);
            if (regex.IsMatch(fieldValid)) return true;

            return false;
        }

        private static bool CompareFieldsValid(string fieldValid, string fieldValCompare)
        {
            if (fieldValid.Equals(fieldValCompare)) return true;

            return false;
        }

        #endregion
    }
}
