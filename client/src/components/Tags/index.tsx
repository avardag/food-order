import { Link } from "react-router-dom";

interface TagProps {
  tags: { name: string; count?: number }[];
  showCount?: boolean;
}
export default function Tags({ tags, showCount }: TagProps) {
  return (
    <div
      className="flex flex-wrap"
      style={{
        justifyContent: showCount ? "center" : "start",
      }}
    >
      {tags.map((tag) => {
        const tagCount = tag.count ? ` (${tag.count})` : "";
        return (
          <Link
            key={tag.name}
            to={`/tag/${tag.name}`}
            className="bg-gray-200 font-semibold text-blue-700 m-1 px-4 py-1 rounded-full"
          >
            {tag.name}
            {showCount && tagCount}
          </Link>
        );
      })}
    </div>
  );
}
