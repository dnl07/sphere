type Props = {
    children: React.ReactNode;
    title?: string,
    subtitle?: string;
}

const PageWrapper = ({ children, title, subtitle }: Props) => {
    return(
        <>
            <div className={`w-full flex justify-center ${title || subtitle ? "border-border border-b" : ""} mb-2`}>
                {title &&
                <div className="w-full max-w-4xl py-2 pl-4">
                    <h1 className="tracking-tight text-3xl align-self-end">{title}</h1>
                    {subtitle && <h2 className="tracking-tight text-md align-self-end text-text-sub">{subtitle}</h2>}
                </div>
            }
            </div> 
            <div className="flex-1 flex flex-col w-full items-center max-w-4xl mx-auto px-4">
                {children}
            </div>       
        </>
    );
}

export default PageWrapper;