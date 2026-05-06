type Props = {
    children: React.ReactNode;
    sideChildren?: React.ReactNode;
    title?: string,
    subtitle?: string;
    bgColor?: string;
}

const PageWrapper = ({ children, title, subtitle, sideChildren, bgColor }: Props) => {
    return(
        <div className={`flex-1 flex flex-col w-full ${bgColor}`}>
            {title &&
                <div className={`w-full flex justify-center  ${title || subtitle ? "border-border border-b" : ""} mb-4`}>

                    <div className="w-full flex max-w-5xl justify-center items-center">
                        <div className="w-full py-2 pl-4">
                            <h1 className="tracking-tight text-3xl align-self-end">{title}</h1>
                            {subtitle && <h2 className="tracking-tight text-md align-self-end text-text-sub">{subtitle}</h2>}
                        </div>
                        {sideChildren && <div>
                            {sideChildren}
                        </div>}
                    </div>
                </div> 
            }
            <div className="flex-1 flex flex-col w-full items-center max-w-5xl mx-auto px-4">
                {children}
            </div>       
        </div>
    );
}

export default PageWrapper;