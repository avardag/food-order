import {useEffect, useState} from 'react';
import {useNavigate, useParams} from 'react-router-dom';
import styles from './search.module.css';

interface SearchProps {
    searchRoute?: string;
    defaultRoute?: string;
    margin?: string;
    placeholder?: string;
}

export default function Search({
                                   searchRoute = '/search/',
                                   defaultRoute = '/',
                                   placeholder = 'Search your favorite food...',
                                   margin,
                               }: SearchProps) {
    const [term, setTerm] = useState('');
    const navigate = useNavigate();
    const {searchTerm} = useParams();

    useEffect(() => {
        setTerm(searchTerm ?? '');
    }, [searchTerm]);

    const search = () => {
        term ? navigate(searchRoute + term) : navigate(defaultRoute);
    };
    return (
        <div className={styles.container} style={{margin}}>
            <input
                type="text"
                placeholder={placeholder}
                onChange={e => setTerm(e.target.value)}
                onKeyUp={e => e.key === 'Enter' && search()}
                value={term}
            />
            <button onClick={search}>Search</button>
        </div>
    );
}