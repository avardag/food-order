interface TitleProps {
  title: string;
  fontSize?: number;
  margin?: string;
}

export default function Title({ title, fontSize = 32, margin }: TitleProps) {
  return <h1 style={{ fontSize, margin, color: "#616161" }}>{title}</h1>;
}
