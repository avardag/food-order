interface PriceProps {
    price: number;
    locale?: string;
    currency?: string;
} 
export default function Price({ price, locale='en-US', currency='USD' }:PriceProps) {
    const formatPrice = () =>
        new Intl.NumberFormat(locale, {
            style: 'currency',
            currency,
        }).format(price);

    return <span>{formatPrice()}</span>;
}
