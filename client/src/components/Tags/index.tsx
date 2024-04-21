import { Link } from 'react-router-dom';
import styles from './tags.module.css';
import { TagList } from '../../shared/types';

interface TagProps {
    tags: TagList[];
    forFoodPage?: boolean;
}
export default function Tags({ tags, forFoodPage }:TagProps) {
    return (
        <div
            className={styles.container}
            style={{
                justifyContent: forFoodPage ? 'start' : 'center',
            }}
        >
            {tags.map(tag => (
                <Link key={tag.name} to={`/tag/${tag.name}`}>
                    {tag.name}
                    {!forFoodPage && `(${tag.count})`}
                </Link>
            ))}
        </div>
    );
}