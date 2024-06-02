import types from "./inputContainer.module.css";

interface InputContProps {
  label: string;
  bgColor?: string;
  children: React.ReactNode;
}
export default function InputContainer({
  label,
  bgColor,
  children,
}: InputContProps) {
  return (
    <div className={types.container} style={{ backgroundColor: bgColor }}>
      <label className={types.label}>{label}</label>
      <div className={types.content}>{children}</div>
    </div>
  );
}
