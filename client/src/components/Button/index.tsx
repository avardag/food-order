import styles from "./button.module.css";

interface ButtonProps {
  type?: "button" | "submit" | "reset" | undefined;
  text: string;
  onClick?: () => void;
  color?: string;
  backgroundColor?: string;
  fontSize?: string;
  width?: string;
  height?: string;
}

export default function Button({
  type = "button",
  text = "Submit",
  onClick,
  backgroundColor = "#e72929",
  color = "white",
  fontSize = "1.3rem",
  width = "12rem",
  height = "3.5rem",
}: ButtonProps) {
  return (
    <div className={styles.container}>
      <button
        style={{
          color,
          backgroundColor,
          fontSize,
          width,
          height,
        }}
        type={type}
        onClick={onClick}
      >
        {text}
      </button>
    </div>
  );
}
