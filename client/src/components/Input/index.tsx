import React from "react";
import InputContainer from "../InputContainer";
import styles from "./input.module.css";
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
  ref: React.LegacyRef<HTMLInputElement> | undefined,
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
        className={styles.input}
        type={type}
        placeholder={label}
        ref={ref}
        name={name}
        onChange={onChange}
        onBlur={onBlur}
      />
      {error && <div className={styles.error}>{getErrorMessage()}</div>}
    </InputContainer>
  );
}

const Input = React.forwardRef(InputComponent);

export default Input;
