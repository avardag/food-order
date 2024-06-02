import { Link } from "react-router-dom";
import styles from "./tags.module.css";
import { Tag } from "../../shared/types";

interface TagProps {
  tags: Tag[];
  showCount?: boolean;
}
export default function Tags({ tags, showCount }: TagProps) {
  return (
    <div
      className={styles.container}
      style={{
        justifyContent: showCount ? "center" : "start",
      }}
    >
      {tags.map((tag) => (
        <Link key={tag.name} to={`/tag/${tag.name}`}>
          {tag.name}
          {/* {showCount && `(${tag.count})`} */}
        </Link>
      ))}
    </div>
  );
}

