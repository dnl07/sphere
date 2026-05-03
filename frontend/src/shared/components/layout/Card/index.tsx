type Props = {
    title?: string;
    children: React.ReactNode;
    className?: string;
}

const Card = ({ title, children, className = "" }: Props) => (
    <div className={`w-full bg-bg-elevated rounded-xl p-6 ${className}`}>
        {title && <h3 className="text-lg font-semibold mb-4">{title}</h3>}
        {children}
    </div>
);

export default Card;