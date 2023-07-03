using System;
using System.Collections.Generic;
using System.Text;

namespace ClubMembershipApplication.FieldValidators
{
    /*
     * Delegate that references a method for validating fields presetned to user in user registration view class
     * @param fieldIndex - references a particular field in an array of fields
     * @param fieldValue - field value to be validated
     * @param fieldArray - stores all validated fields for a particular view
     * @param fieldInvalidMessage - value to be outputted to calling code 
     */
    public delegate bool FieldValidatorDel(int fieldIndex, string fieldValue, string[] fieldArray, out string fieldInvalidMessage);

    public interface IFieldValidator
    {
        void InitailzeValidatorDelegates();
        string[] FieldArray { get; }
        FieldValidatorDel ValidatorDel { get; }
    }
}
