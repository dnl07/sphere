import type { IconProps } from "../IconBase";
import IconBase from "../IconBase";

const LoadingIcon = (props: IconProps) => {
    return (
        <IconBase {...props}>
            <style>{`
                @keyframes spin {
                    from { transform: rotate(0deg); }
                    to { transform: rotate(360deg); }
                }
                .loading-spin {
                    transform-origin: center;
                    animation: spin 1s linear infinite;
                }
            `}</style>
            <g className="loading-spin">
                <mask id="mask0_2_2" style={{maskType: "alpha"}} maskUnits="userSpaceOnUse" x="12" y="1" width="12" height="22">
                    <rect x="12" y="1" width="12" height="22" fill="white"/>
                </mask>
                <g mask="url(#mask0_2_2)">
                    <path d="M12 3C16.9706 3 21 7.02944 21 12C21 16.9706 16.9706 21 12 21C7.02944 21 3 16.9706 3 12C3 7.02944 7.02944 3 12 3Z" stroke="url(#paint0_linear_2_2)"/>
                </g>
                <mask id="mask1_2_2" style={{maskType: "alpha"}} maskUnits="userSpaceOnUse" x="0" y="0" width="12.1" height="23">
                    <rect x="0.0106679" width="12" height="22" transform="rotate(0.027783 0.0106679 0)" fill="white"/>
                </mask>
                <g mask="url(#mask1_2_2)">
                    <path d="M12 21C7.02944 21 3 16.9706 3 12C3 7.02944 7.02944 3 12 3C16.9706 3 21 7.02944 21 12C21 16.9706 16.9706 21 12 21Z" stroke="url(#paint1_linear_2_2)"/>
                </g>
                <defs>
                    <linearGradient id="paint0_linear_2_2" x1="12" y1="2" x2="12" y2="22" gradientUnits="userSpaceOnUse">
                        <stop/>
                        <stop offset="0.9" stopColor="#777777"/>
                    </linearGradient>
                    <linearGradient id="paint1_linear_2_2" x1="12" y1="22" x2="12" y2="2" gradientUnits="userSpaceOnUse">
                        <stop offset="0.375" stopColor="#777777"/>
                        <stop offset="1" stopColor="#DCDCDC"/>
                    </linearGradient>
                </defs>
            </g>
        </IconBase>
    );
}

export default LoadingIcon;