import React from "react";
import InputContainer from "../InputContainer";
import { FieldError } from "react-hook-form";

interface InputProps {
  label: string;
  type: React.HTMLInputTypeAttribute;
  defaultValue?: string;
  onChange: React.ChangeEventHandler;
  onBlur: React.FocusEventHandler<HTMLInputElement>;
  name: string;
  error: FieldError | undefined;
}

function InputComponent(
  { label, type, defaultValue, onChange, onBlur, name, error }: InputProps,
  ref: React.LegacyRef<HTMLInputElement> | undefined
) {
  const getErrorMessage = () => {
    if (!error) return null;
    if (error.message) return error.message;
    //defaults
    switch (error.type) {
      case "required":
        return "This Field Is Required";
      case "minLength":
        return "Field Is Too Short";
      default:
        return "*";
    }
  };

  return (
    <InputContainer label={label}>
      <input
        defaultValue={defaultValue}
        className="w-full h-full transition-[border-width] duration-[0.15s] ease-[ease-out] bg-white text-lg border-b-grey-300  focus:border-b-2 outline-none"
        type={type}
        placeholder={label}
        ref={ref}
        name={name}
        onChange={onChange}
        onBlur={onBlur}
      />
      {error && (
        <div className="flex justify-center items-center absolute h-full w-48 text-red-500 text-center text-sm right-0 top-0">
          {getErrorMessage()}
        </div>
      )}
    </InputContainer>
  );
}

const Input = React.forwardRef(InputComponent);

export default Input;
