interface StarRatingProps {
    stars: number;
    size?: number;
}
export default function StarRating({ stars, size=18 }:StarRatingProps) {
    const styles = {
        width: size + 'px',
        height: size + 'px',
        marginRight: size / 6 + 'px',
    };

    function Star({ number }:{number:number}) {
        const halfNumber = number - 0.5;

        return stars >= number ? (
            <img src="/star-full.svg" style={styles} alt={number.toString()} />
        ) : stars >= halfNumber ? (
            <img src="/star-half.svg" style={styles} alt={number.toString()} />
        ) : (
            <img src="/star-empty.svg" style={styles} alt={number.toString()} />
        );
    }

    return (
        <div style={{display: 'flex', flexWrap:"nowrap"}}>
            {[1, 2, 3, 4, 5].map(number => (
                <Star key={number} number={number} />
            ))}
        </div>
    );
}
