type Props = {
    title?: string;
    children: React.ReactNode;
    className?: string;
}

const Card = ({ title, children, className = "" }: Props) => (
    <div className={`w-full bg-bg-elevated rounded-xl px-6 py-4 ${className}`}>
        {title && <h3 className="text-lg font-semibold mb-2">{title}</h3>}
        {children}
    </div>
);

export default Card;