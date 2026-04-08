type Props = {
    children: React.ReactNode;
    title?: string
}

const PageWrapper = ({ children, title }: Props) => {
    return(
        <div className="flex-1 flex flex-col w-full items-center max-w-4xl mx-auto px-4">
            {title && 
                 <div className=" w-full border-b mb-2 py-2">
                    <h1 className="text-3xl align-self-end px-2 py-1">{title}</h1>
                </div>
            }
            {children}
        </div>
    );
}

export default PageWrapper;