interface InputContProps {
  label: string;
  bgColor?: string;
  children: React.ReactNode;
}
export default function InputContainer({
  label,
  bgColor = "white",
  children,
}: InputContProps) {
  return (
    <div
      className="relative border mb-4 p-1 rounded-xl border-solid border-gray-200"
      style={{ backgroundColor: bgColor }}
    >
      <label className="inline-block text-gray-500 text-base ml-2">
        {label}
      </label>
      <div className="h-12 flex items-center px-2 py-0 outline-none border-none">
        {children}
      </div>
    </div>
  );
}
